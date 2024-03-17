using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpawner : MonoBehaviour
{

    [SerializeField] GameObject enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        if (enemySpawner == null)
        {
            enemySpawner = GetComponentInChildren<EnemySpawner>().gameObject;
        }
    }

    public void activateSpawner()
    {
        if (!enemySpawner.activeSelf)
        {
            enemySpawner.SetActive(true);
        }
    }
}
