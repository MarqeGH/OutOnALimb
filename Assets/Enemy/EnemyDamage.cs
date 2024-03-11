using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    public int damageDealt;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.ApplyDamage(damageDealt);
        }
    }
}
