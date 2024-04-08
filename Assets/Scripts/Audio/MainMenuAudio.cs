using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip uiAcceptClip;
    [SerializeField] private AudioClip uiBackClip;
    [SerializeField] private AudioClip uiHoverClip;
    public void PlayUiAccept(){
    AudioManager.Instance.PlayAudioOneShot(audioSource, uiAcceptClip);

    }

    public void PlayUiBack(){
    AudioManager.Instance.PlayAudioOneShot(audioSource, uiBackClip);
    
    }
    public void PlayUiHover(){
    // AudioManager.Instance.PlayAudioOneShot(audioSource, uiHoverClip);
    
    }
}
