using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    [NonSerialized] public int currentHealth;

    public CharacterController playerController;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        Debug.Log("I'm so death");
        // player death animation
        // trigger "you died" screen
    }
}
