using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject settingsScreen;
    public string sceneStart;
    public void StartGame()
    {
        SceneManager.LoadScene(sceneStart);
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
