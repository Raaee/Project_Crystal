using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{

    public GameObject[] tabs;

    public void openTab(int buttonIndex)
    {
        for (int i = 0; i < 4; i++)
        {
            if (buttonIndex == i)
            {
                tabs[i].SetActive(true);
            }
            else
            {
                tabs[i].SetActive(false);
            }
        }
    }
}
