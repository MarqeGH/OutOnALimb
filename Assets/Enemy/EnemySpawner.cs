using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner pool;
    public List<GameObject> pooledObjects;
    public GameObject enemyPrefab;
    public int poolSize = 30;

    void Awake()
    {
        pool = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < poolSize; ++i)
        {
            tmp = Instantiate(enemyPrefab);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
        StartCoroutine("SpawnEnemies");
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolSize; ++i)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
