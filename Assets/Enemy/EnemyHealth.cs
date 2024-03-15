using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Pool;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth;
    [NonSerialized] public int currentHealth;
    [SerializeField] UnityEvent enemyRelease;
    [SerializeField] float timeTillDeath = 3;
    bool isDead;

    CapsuleCollider cc;
    NavMeshAgent nma;
    Rigidbody rb;

    void Awake()
    {
        cc = GetComponent<CapsuleCollider>();
        nma = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }
    void OnEnable()
    {
        isDead = false;
        cc.enabled = true;
        nma.speed = 12;
        rb.isKinematic = false;
        rb.useGravity = true;
        if (currentHealth != maxHealth)
        {
            currentHealth = maxHealth;
            // Debug.Log(isDead + " " + currentHealth);    
        }
    }

    public void ApplyDamage(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            EnemyDeath();
        }
    }

    void EnemyDeath()
    {
        if(isDead)return;
        // Debug.Log("dead once");
        isDead = true;

        nma.speed = 0;
        cc.enabled = false;
        // Debug.Log("I'm so death");
        StartCoroutine(DelayedDeath());
        // enemy death animation
    }

    private IEnumerator DelayedDeath()
    {
        yield return new WaitForSeconds(timeTillDeath);
        enemyRelease?.Invoke();
    }
}
