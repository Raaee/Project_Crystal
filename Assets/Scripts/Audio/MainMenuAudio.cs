using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource hoverAudioSource;
    [SerializeField] private AudioClip uiAcceptClip;
    [SerializeField] private AudioClip uiBackClip;
    [SerializeField] private AudioClip uiHoverClip;
    [SerializeField] private AudioClip startMainMenuClip;

    [Header("Audio Mixer Slider")]
    [SerializeField] private AudioMixer mainAudioMixer;
    [SerializeField] private Slider musicSlidre;

    [SerializeField] private Slider sfxSlidre;


    private void Start()
    {
        musicSlidre.onValueChanged.AddListener(SetMusicVolume);
        sfxSlidre.onValueChanged.AddListener(SetSFXVolume);
        AudioManager.Instance.PlayAudioOneShot(hoverAudioSource, startMainMenuClip);
    }
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
        Debug.Log("setting sfx " + sliderValue);
        mainAudioMixer.SetFloat("SfxVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetMusicVolume(float sliderValue)
    {
        Debug.Log("setting music " + sliderValue);
        mainAudioMixer.SetFloat("MusicVol", (Mathf.Log10(sliderValue) * 20) -6);
       
    }
}
