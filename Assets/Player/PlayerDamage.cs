using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damageDealt;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("it's hitting... something ?");
        if (other.CompareTag("Enemy"))
        {
            var enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            Debug.Log("Hit: " + other);
            enemyHealth.ApplyDamage(damageDealt);
            Destroy(gameObject);
        }
    }
}
