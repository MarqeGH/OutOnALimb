using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Button exitButton;
    [SerializeField] Button resumeButton;
    void Start()
    {
        resumeButton.onClick.AddListener(ResumeGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame

    void ResumeGame()
    {
        gameObject.SetActive(false);
        if (Time.timeScale < 1)
        {
            Time.timeScale = 1;
        }
    }
    
    void ExitGame()
    {
        Application.Quit();
    }

}
