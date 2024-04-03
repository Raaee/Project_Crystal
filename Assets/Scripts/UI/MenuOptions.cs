using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject characterSelectScreen;
    [SerializeField] private GameObject creditsScreen;
    public string sceneStart;
    public void StartGame()
    {
        
            
        characterSelectScreen.SetActive(true);
        menuScreen.SetActive(false);
        Debug.Log("Open Character Select Screen");
        
        
    }

    public void startPlayGame()
    {
        
        CharacterDataSO chosenPlayer = FindObjectOfType<CharacterSelectUI1>().getCurrentCharacterData();
        ChosenPlayerData.Instance.setChosenPlayer(chosenPlayer);
        SceneManager.LoadScene(sceneStart);
    }

    public void OpenCredits()
    {
        Debug.Log("Open Credits Screen");
    }

    public void OpenSettingsScreen()
    {
        settingsScreen.SetActive(true);
        menuScreen.SetActive(false);
    }

    public void backToMainMenu()
    {
        menuScreen.SetActive(true);
        characterSelectScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Close Game");
    }

    public void OpenCreditsScreen()
    {
        creditsScreen.SetActive(true);
        menuScreen.SetActive(false);
    }


    public void CloseCreditsScreen()
    {

        creditsScreen.SetActive(false);
        menuScreen.SetActive(true);

    }
}
