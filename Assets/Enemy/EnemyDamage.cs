using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    float attackSpeed = 1f;
    float timePassed;
    public int damageDealt;

    void Update()
    {
        timePassed += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player") && timePassed > attackSpeed)
        {
            var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.ApplyDamage(damageDealt);
            timePassed = 0;
        }
    }
}
