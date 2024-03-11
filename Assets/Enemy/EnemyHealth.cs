using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth;
    [NonSerialized] public int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(int dmg)
    {
        Debug.Log("Health before hit: " + currentHealth);
        currentHealth -= dmg;
        Debug.Log("Health after hit: " + currentHealth);
        if (currentHealth <= 0)
        {
            EnemyDeath();
        }
    }

    void EnemyDeath()
    {
        Debug.Log("I'm so death");
        // player death animation
        // trigger "you died" screen
    }
}
