using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    public ObjectPool<MoveEnemy> _pool;
    public MoveEnemy prefab;

    [SerializeField] Transform playerPos;
    [SerializeField] Transform triggerPos;
    [SerializeField] int defaultPool;
    [SerializeField] int poolSize;
    [SerializeField] float spawnTimer = 5;
    bool doSpawn = true;
    float timePassed;

    float playerDistance;


    void Start()
    {
    _pool = new ObjectPool<MoveEnemy>(CreateEnemy, OnGetEnemyFromPool, OnReleaseEnemyFromPool, OnDestroyEnemyFromPool, true, defaultPool, poolSize);
    // POOL ORDER: (D)Create P on load --> (D-)Action on get P --> Action on Destroy P --/
    //--> Collection Check(did I already release P?) --> Default Capacity --> Max Capacity
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        // if (Time.timeSinceLevelLoad%spawnTimer <= 0 && doSpawn == true)
        // {
        //     doSpawn = false;
        //     _pool.Get();
        // }
        // else if (Time.timeSinceLevelLoad%spawnTimer > 0)
        // {
        //     doSpawn = true;
        // }
        playerDistance = Vector3.Distance(playerPos.position, triggerPos.position);
        spawnTimer = playerDistance/8f;
        if (timePassed > spawnTimer+0.1f)
        {
            _pool.Get();
            timePassed = 0;
        }

        Debug.Log("playerDistance: " + playerDistance + ", timer: " + spawnTimer + "remainder: " + Time.timeSinceLevelLoad%spawnTimer);
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
