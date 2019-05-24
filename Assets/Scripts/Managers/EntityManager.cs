using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour {

    #region Singletone
    public static EntityManager Singletone = null;

    void Awake() {
        if (Singletone != null) {
            Debug.LogError("An instance of EnemyManager already exists in the hierarchy");
            return;
        }

        Singletone = this;
    }
    #endregion

    [SerializeField]
    private GameObject[] Enemies;
    [SerializeField]
    private GameObject[] Gems;
    [SerializeField]
    private GameObject Heart;

    [SerializeField]
    private EntitySpawn[] ProjectileSpawns;
    [SerializeField]
    private EntitySpawn HealthSpawn;

    [SerializeField]
    private float SpawnRate = 2f;
    [SerializeField]
    private float SpawnStartDelay = 2f;

    public bool Spawning { get; protected set; }

    List<GameObject> currEntities = new List<GameObject>();

    // Use this for initialization
    void Start() {

        //InvokeRepeating("spawnEntities", SpawnRate, SpawnStartDelay);
    }

    // Update is called once per frame
    void Update() {

        //Debug.Log(Spawning);
    }

    GameObject heart = null;

    void spawnHearts() {

        if (heart == null && Data.Lives < 3) {

            int spawn = UnityEngine.Random.Range(0, TileManager.instance.TileCoords.Count);

            heart = HealthSpawn.Spawn(Heart, TileManager.instance.TileCoords[spawn] + Vector3.up / 2f);
        }
    }

    float lastTime = 0f;
    float timePassed = 0f;

    void spawnProjectiles() {

        if (Spawning && Data.Lives > 0) {

            if (lastTime == 0) {
                lastTime = Time.time;
            }

            timePassed += Time.deltaTime * 1f;

            lastTime = Time.time;

            //Debug.Log(timePassed);

            foreach (var e in ProjectileSpawns) {

                float chance = Sigmoid(timePassed - 1f);

                Debug.Log("EntityManager::spawnProjectiles() => timePassed = " + timePassed);
                Debug.Log("EntityManager::spawnProjectiles() => chance = " + chance);

                //TODO: Add more sophisticated method of determening the entity
                GameObject entity = chance * 100 < UnityEngine.Random.Range(0f, 100f) ? Gems[0] : Enemies[0];

                e.Spawn(entity, Vector3.zero);
            }
        }
    }

    bool heartSpawnsInvoking = false;

    public void StartHeartSpawningLoop() {

        if (heartSpawnsInvoking == false) {

            InvokeRepeating("spawnHearts", 0f, 1f);

            heartSpawnsInvoking = true;
        }
    }

    public void EndHeartSpawningLoop() {

        heartSpawnsInvoking = false;

        CancelInvoke("spawnHearts");
    }

    bool projectileSpawnsInvoking = false;

    public void StartProjectileSpawningLoop() {

        if (projectileSpawnsInvoking == false) {

            InvokeRepeating("spawnProjectiles", SpawnRate, SpawnStartDelay);

            projectileSpawnsInvoking = true;
        }
    }

    public void EndProjectileSpawningLoop() {

        CancelInvoke("spawnProjectiles");

        projectileSpawnsInvoking = false;

        lastTime = 0f;

        timePassed = 0f;
    }

    public void SetSpawning(bool s, string sender) {

        //Debug.Log("Sender, " + s);

        Spawning = s;
    }

    public GameObject[] GetEnemies() {

        return Enemies;
    }

    float Sigmoid(float x) {

        return 1f / (1f + Mathf.Exp(-x));
    }
}
