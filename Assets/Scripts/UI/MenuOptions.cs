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

    void Start()
    {
        BackToMainMenu();
    }
    public void StartGame() {
        menuScreen.SetActive(false);
        characterSelectScreen.SetActive(true);
    }
    public void Play()
    {
        CharacterDataSO chosenPlayer = FindObjectOfType<CharacterSelectUI>().getCurrentCharacterData();
        ChosenPlayerData.Instance.SetChosenPlayer(chosenPlayer);
        SceneManager.LoadScene(sceneStart);
    }
    public void OpenSettingsScreen()
    {
        settingsScreen.SetActive(true);
        menuScreen.SetActive(false);
    }
    public void BackToMainMenu()
    {
        menuScreen.SetActive(true);
        characterSelectScreen.SetActive(false);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Close Game");
    }
    public void OpenCreditsScreen()
    {
        menuScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }
    public void CloseCreditsScreen()
    {

        creditsScreen.SetActive(false);
        menuScreen.SetActive(true);

    }
}
