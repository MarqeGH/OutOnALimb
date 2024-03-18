using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{

    [SerializeField] GameObject winnerScreen;
    [SerializeField] PlayerHealth invincibleCheck;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            winnerScreen.SetActive(true);
            Invoke("GoToCredits", 5f);
            invincibleCheck.invincible = true;
        }
    }

    void GoToCredits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
