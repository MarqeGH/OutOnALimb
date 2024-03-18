using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject activeUI;
    [SerializeField] Button retryButton;
    [SerializeField] Button exitButton;
    void Start()
    {
        retryButton.onClick.AddListener(RetryGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame

    void RetryGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    
    void ExitGame()
    {
        Debug.Log("exiting game");
        Application.Quit();
    }


    void OnEnable()
    {
        activeUI.SetActive(false);
    }
}
