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

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthBarUI.fillAmount = currentHealth/maxHealth;
    }

    public void ApplyDamage(int dmg)
    {
        currentHealth -= dmg;

        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        characterController.enabled = false;
        characterMovement.enabled = false;
        Debug.Log("I'm so death");
        animator.SetBool("isDead", true);
        // player death animation
        // trigger "you died" screen
    }
}
