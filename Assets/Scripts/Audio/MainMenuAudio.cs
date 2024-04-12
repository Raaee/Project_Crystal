using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenuAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource hoverAudioSource;
    [SerializeField] private AudioClip uiAcceptClip;
    [SerializeField] private AudioClip uiBackClip;
    [SerializeField] private AudioClip uiHoverClip;

    [Header("Audio Mixer Slider")]
    [SerializeField] private AudioMixer mainAudioMixer;
  
  
    public void PlayUiAccept(){
    AudioManager.Instance.PlayAudioOneShot(audioSource, uiAcceptClip);

    }

    public void PlayUiBack(){
    AudioManager.Instance.PlayAudioOneShot(audioSource, uiBackClip);
    
    }
    public void PlayUiHover(){
     AudioManager.Instance.PlayAudioOneShot(hoverAudioSource, uiHoverClip);
    
    }


    public void SetSFXVolume(float sliderValue)
    {
        mainAudioMixer.SetFloat("SfxVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetMusicVolume(float sliderValue)
    {
        mainAudioMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
       
    }
}
