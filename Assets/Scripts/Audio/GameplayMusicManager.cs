using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMusicManager : MonoBehaviour
{

    [SerializeField] private MusicLayerSystem musicCombatSystem;
    [SerializeField] private GamePlayIdleMusic gameplayIdleMusic;
    int currentIntensity = 0;

    private void Start()
    {
        StartIdleMusic();
        SetupListeners();
        CrystalManager.Instance.OnCrystalActivate.AddListener(TransitionToCombatMusic);
        CrystalManager.Instance.OnCrystalDeActivate.AddListener(TransitionToIdleMusic);
    }
    public void StartIdleMusic()
    {
        gameplayIdleMusic.StartIdleMusic();
    }

    public void TransitionToCombatMusic()
    {
        gameplayIdleMusic.StopIdleMusic();
        DetermineCombatMusicIntensity();
        musicCombatSystem.StartMusicSystem();
    }

    private void DetermineCombatMusicIntensity()
    {


         currentIntensity = DetermineStartingIntensity();


       for (int i = 0; i < currentIntensity; i++)
        {
            musicCombatSystem.IncreaseIntensity();
        }
    }
    private void SetupListeners()
    {
        List<Crystal> allCrystals = CrystalManager.Instance.crystals;
       
        foreach(Crystal crystal in allCrystals)
        {
            crystal._OnNextWaveStarted.AddListener(IncreaseIntensity);
        }
    }

    private void IncreaseIntensity()
    {
        musicCombatSystem.IncreaseIntensity();
    }

    private int DetermineStartingIntensity()
    {
        int totalCrystals = CrystalManager.Instance.crystals.Count;
        int crystalsSaved = CrystalManager.Instance.GetCrystalsSavedAmount();
        float percentageSaved = (float)crystalsSaved / totalCrystals;
        Debug.Log("Percentage saved is " + percentageSaved);
        if (percentageSaved < 0.33f)
            return 0;
        else if (percentageSaved > 0.33f && percentageSaved < 0.66f)
            return 1;
        else
            return 2;
    }

    public void TransitionToIdleMusic()
    {
        musicCombatSystem.StopMusicSystem();
        gameplayIdleMusic.StartIdleMusic();
    }
}
