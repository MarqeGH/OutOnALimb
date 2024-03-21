using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{

    [SerializeField] GameObject winnerScreen;
    [SerializeField] PlayerHealth invincibleCheck;
    [SerializeField] SoundEffects soundEffect;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            winnerScreen.SetActive(true);
            soundEffect.PlayClip(soundEffect.complete);
            Invoke("GoToCredits", 5f);
            invincibleCheck.invincible = true;
        }
    }

    void GoToCredits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
