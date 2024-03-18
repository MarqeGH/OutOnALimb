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
    float attackSpeed = 1f;
    float timePassed;
    int random;
    GameObject currentSkin;

    List<GameObject> enemySkin = new List<GameObject>();

    void Start()
    {
        player = GameObject.Find("Player");
        animator = enemy.GetComponent<Animator>();
        animator.applyRootMotion = true;
        enemy.updatePosition = true;
        enemy.updateRotation = true;
        enemy.speed = 14f;
        DefineSkinAtStart();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (enemy.enabled)
        {
            enemy.SetDestination(player.transform.position);
        }
        handleAnimations();
    }

    void handleAnimations()
    {
        float distance = Vector3.Distance(enemy.transform.position, player.transform.position);
        if (distance > enemy.stoppingDistance)
        {
            animator.SetBool("move", true);
        }
        else
        {
            animator.SetBool("move", false);
            handleAttack();
        }
    }

    void handleAttack(){
        if (timePassed > attackSpeed)
        {
            transform.LookAt(player.transform);
            animator.SetBool("isAttacking", true);
            timePassed = 0;
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

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

    void DefineSkinAtStart()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (!child.gameObject.activeSelf)
            {
                Debug.Log(child);
                enemySkin.Add(child.gameObject);
            }
        }
        random = Random.Range(0, enemySkin.Count);
        currentSkin = enemySkin[random];
        currentSkin.SetActive(true);
        Debug.Log(enemySkin);
    }


    public void SetPool(ObjectPool<MoveEnemy> pool)
    {
        // Debug.Log(_pool + " before");
        _pool = pool;
        // Debug.Log(_pool + " after");
    }
}
