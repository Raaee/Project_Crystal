using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject characterSelectScreen;
    public string sceneStart;
    public void StartGame()
    {
        // SceneManager.LoadScene(sceneStart);
        characterSelectScreen.SetActive(true);
    }

    public void OpenCredits()
    {
        Debug.Log("Open Credits Screen");
    }

    public void OpenSettingsScreen()
    {
          if (menuScreen != null && settingsScreen != null)
    {
        settingsScreen.SetActive(true);
        menuScreen.SetActive(false);
        Debug.Log("Opening Settings Screen");
    }
    else
    {
        Debug.Log("There is no instance of menu and setting screen in the editor");
    }
    }

    public void QuitGame()
    {
        Debug.Log("Close Game");
    }
}
