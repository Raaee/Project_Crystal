using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsOptions : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject settingsScreen;
    public GameObject selectCharacterScreen;

   public void ExitSettingsScreen()
   {
    Debug.Log("Exiting Settings");
    menuScreen.SetActive(true);
    settingsScreen.SetActive(false);
   }


   public void ExitCharacterSelectScreen()
   {
    selectCharacterScreen.SetActive(false);
    menuScreen.SetActive(true);    
   }
   
}
