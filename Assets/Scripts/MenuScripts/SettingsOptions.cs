using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsOptions : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject settingsScreen;

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
}
