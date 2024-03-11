using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] Button startMenuBtn;
    // Start is called before the first frame update
    void Start()
    {
        startMenuBtn.onClick.AddListener(GoToStartMenu);
    }
    void GoToStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
