using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LowPlayerHealthAudioState : MonoBehaviour
{
    private PlayerHealthPoints playerHealth;
    private bool isInLowHealth = false;
    private const float LOW_HEALTH_PERCENTAGE = 0.25f;
    private const float TRANSITION_TIME = 0.75f;
    [SerializeField] private AudioMixerSnapshot normalState;
    [SerializeField] private AudioMixerSnapshot pausedState;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealthPoints>();
        if(playerHealth == null)
        {
            Debug.LogError("No player with health points in the scene");
        }

        playerHealth.OnHealthChange.AddListener(HandleLowHealthStateAudio);
    }

    private void HandleLowHealthStateAudio()
    {
        float currentHealthPercentage = (float)playerHealth.GetCurrentHP() / playerHealth.GetMaxHealth();

        if(currentHealthPercentage < LOW_HEALTH_PERCENTAGE)
        {
            if (isInLowHealth) return; //already in low health, do nothing
            isInLowHealth = true;
            LowHealthState();
        }
        else
        {
            if (!isInLowHealth) return; //already not in low health, do nothing
            isInLowHealth = false;
            NormalHealthState();
        }

    }

    private void NormalHealthState()
    {
        normalState.TransitionTo(TRANSITION_TIME);
    }

    private void LowHealthState()
    {
        pausedState.TransitionTo(TRANSITION_TIME);
    }
}
