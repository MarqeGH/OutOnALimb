using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    public ObjectPool<MoveEnemy> _pool;
    public MoveEnemy prefab;
    [SerializeField] int defaultPool;
    [SerializeField] int poolSize;
    [SerializeField] float spawnTimer = 5;
    bool doSpawn = true;


    void Start()
    {
    _pool = new ObjectPool<MoveEnemy>(CreateEnemy, OnGetEnemyFromPool, OnReleaseEnemyFromPool, OnDestroyEnemyFromPool, true, defaultPool, poolSize);
    // POOL ORDER: (D)Create P on load --> (D-)Action on get P --> Action on Destroy P --/
    //--> Collection Check(did I already release P?) --> Default Capacity --> Max Capacity
    }

    void Update()
    {
        if ((int)Time.timeSinceLevelLoad%spawnTimer == 0 && doSpawn == true)
        {
            doSpawn = false;
            _pool.Get();
        }
        else if ((int)Time.timeSinceLevelLoad%spawnTimer > 0)
        {
            doSpawn = true;
        }
    }
    
    // Create Enemies for pool
    private MoveEnemy CreateEnemy()
    {
        // Spawn new instance of bullet
        MoveEnemy enemy = Instantiate(prefab, transform.position, transform.rotation);

        // Assign the bullet's pool
        enemy.SetPool(_pool);
        
        // return value
        return enemy;
    }
    // What to do when taking enemy from Pool
    private void OnGetEnemyFromPool(MoveEnemy enemy)
    {
        // Reset enemy position & rotation to Weapon pos and Player Rot
        enemy.transform.position = transform.position;
        enemy.transform.rotation = transform.rotation;

        // Activate enemy
        enemy.gameObject.SetActive(true);
    }

    private void OnReleaseEnemyFromPool(MoveEnemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void OnDestroyEnemyFromPool(MoveEnemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}
