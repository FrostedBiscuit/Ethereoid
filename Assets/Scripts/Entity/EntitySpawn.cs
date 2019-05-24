using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawn : MonoBehaviour {
    //Fields
    [SerializeField]
    GameObject EnemyObjectPool = null;

    public bool RandomSpawnRate = true;
    public float SpawnChance = 50; // In %

    public void Start()
    {
        //InvokeRepeating("Spawn", SpawnRate, SpawnRate);
    }

    public GameObject Spawn(GameObject entity, Vector3 offset)
    {
        if (Data.Lives == 0)
            return null;

        int guess = Random.Range(0, 100);
        if (RandomSpawnRate && guess > SpawnChance)
            return null;

        var e = Instantiate(entity, transform.position + offset, transform.rotation);
        if (EnemyObjectPool != null)
            e.transform.SetParent(EnemyObjectPool.transform);

        return e;
    }
}
