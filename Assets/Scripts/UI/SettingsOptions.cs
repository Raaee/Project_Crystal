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
    if (menuScreen != null && settingsScreen != null)
    {
        menuScreen.SetActive(true);
        settingsScreen.SetActive(false);
        Debug.Log("Exiting Settings Screen");
    }
    else
    {
        Debug.Log("There is no instance of menu and setting screen in the editor");
    }
   }


   public void ExitCharacterSelectScreen()
   {
    if(menuScreen != null && selectCharacterScreen != null)
    {
        menuScreen.SetActive(true);
        selectCharacterScreen.SetActive(false);
        Debug.Log("Exiting Select Character Screen");
    }else
    {
        Debug.Log("There is no instance of menu and character select screen in the editor");
    }
    
   }
   
}
