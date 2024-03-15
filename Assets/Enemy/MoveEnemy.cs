using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class MoveEnemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    GameObject player;
    private ObjectPool<MoveEnemy> _pool;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.enabled)
        {
            enemy.SetDestination(player.transform.position);
        }
    }

    public void EnemyRelease()
    {
        if (_pool==null)return;
        _pool.Release(this);
    }



    public void SetPool(ObjectPool<MoveEnemy> pool)
    {
        // Debug.Log(_pool + " before");
        _pool = pool;
        // Debug.Log(_pool + " after");
    }
}
