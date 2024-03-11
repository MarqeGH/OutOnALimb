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
    void Update()
    {
        
    }

    void ResumeGame()
    {
        gameObject.SetActive(false);
    }
    
    void ExitGame()
    {
        Debug.Log("exiting game");
        Application.Quit();
    }

}
