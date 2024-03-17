using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] ActivateSpawner spawner;
    bool hasSpawned = false;

    void OnTriggerEnter(Collider other) {
        if (other.transform.root.CompareTag("Player") && hasSpawned == false)
        {
            spawner.activateSpawner();
            hasSpawned = true;
        }
    }
}
