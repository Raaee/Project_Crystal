using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    private MusicLayerSystem mainMenuMusic;

    private void Start()
    {
        mainMenuMusic = GetComponent<MusicLayerSystem>();
        mainMenuMusic.StartMusicSystem();
    }

    public void Increase()
    {
        mainMenuMusic.IncreaseIntensity();
    }

    public void Decrease()
    {
        mainMenuMusic.DecreaseIntensity();
    }

}
