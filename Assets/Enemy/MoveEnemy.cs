using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class MoveEnemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    Animator animator;
    GameObject player;
    private ObjectPool<MoveEnemy> _pool;
    Vector2 Velocity;
    Vector2 SmoothDeltaPosition;

    void Start()
    {
        player = GameObject.Find("Player");
        animator = enemy.GetComponent<Animator>();
        animator.applyRootMotion = true;
        enemy.updatePosition = true;
        enemy.updateRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.enabled)
        {
            enemy.SetDestination(player.transform.position);
        }
        handleAnimations();
    }

    void handleAnimations()
    {
        float distance = Vector3.Distance(enemy.transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance > enemy.stoppingDistance)
        {
            animator.SetBool("move", true);
        }
        else
        {
            animator.SetBool("move", false);
        }
    }

    void handleAttack(){
        
    }

    public void StopMoving()
    {
        enemy.isStopped = true;
        StopAllCoroutines();
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
