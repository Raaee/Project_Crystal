using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject selectCharacterScreen;

   public void ExitSettingsScreen()
   {
    if (menuScreen != null && selectCharacterScreen != null)
    {
        menuScreen.SetActive(true);
        selectCharacterScreen.SetActive(false);
        Debug.Log("Exiting Settings Screen");
    }
    else
    {
        Debug.Log("There is no instance of menu and setting screen in the editor");
    }
   
   }
    
}
