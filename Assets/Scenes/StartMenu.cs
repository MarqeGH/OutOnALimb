using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    [SerializeField] Button exitButton;
    [SerializeField] Button startButton;
    [SerializeField] Button creditsButton;
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        creditsButton.onClick.AddListener(OpenCredits);
        exitButton.onClick.AddListener(ExitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void OpenCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    
    void ExitGame()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
}
