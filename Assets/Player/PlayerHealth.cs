using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    [NonSerialized] public float currentHealth;

    [SerializeField] CharacterController characterController;
    [SerializeField] Character characterMovement;

    [SerializeField] Animator animator;
    [SerializeField] Image healthBarUI;
    [SerializeField] GameObject deathUI;
    float healthRegen = 5;
    bool hasDied = false;
    public bool invincible = false;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthBarUI.fillAmount = currentHealth/maxHealth;
        if (currentHealth < maxHealth)
        {
            currentHealth+= healthRegen*Time.deltaTime;
        }
    }

    public void ApplyDamage(int dmg)
    {
        if(invincible == false)
        {
            currentHealth -= dmg;

            Debug.Log(currentHealth);
            if (currentHealth <= 0)
            {
                PlayerDeath();
            }
        }
    }

    void PlayerDeath()
    {
        if (hasDied == false)
        {
            characterController.enabled = false;
            characterMovement.enabled = false;
            animator.SetBool("isDead", true);
            Invoke("TriggerDeadScreen", 2);
            hasDied = true;
        }
        // player death animation
        // trigger "you died" screen
    }
    void TriggerDeadScreen()
    {
        if (!deathUI.activeSelf)
        {
            deathUI.SetActive(true);    
        }
    }
}
