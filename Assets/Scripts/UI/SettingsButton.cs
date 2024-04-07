using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject musicTab;
    [SerializeField] private GameObject generalTab;


    

    public void openTab()
    {

        musicTab.SetActive(true);
    }



    private void closeAllTabs()
    {
        musicTab.SetActive(false);
    }
}
