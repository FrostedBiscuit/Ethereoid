using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    //Fields
    [SerializeField]
    GameObject EnemyObjectPool = null;

    public float SpawnRate = 2f;
    public bool RandomSpawnRate = true;
    public float SpawnChance = 50; // In %

    public void Start()
    {
        InvokeRepeating("Spawn", SpawnRate, SpawnRate);
    }

    public void Spawn()
    {
        if (Data.Lives == 0)
            return;

        if(transform.parent.name == "Top" && ViewManager.instance.Pos == View.SIDE) 
            return;

        int guess = Random.Range(0, 100);
        if (guess > SpawnChance)
            return;

        var enemy = Instantiate(EntityManager.Singletone.GetEnemies()[0], transform.position, transform.rotation);
        if (EnemyObjectPool != null)
            enemy.transform.SetParent(EnemyObjectPool.transform);
    }
}
