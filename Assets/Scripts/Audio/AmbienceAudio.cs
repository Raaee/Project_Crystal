using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.cyborgAssets.inspectorButtonPro;

public class AmbienceAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ambienceSfxClip;
   
    [SerializeField][Range(0.01f,2f)] private float transitionTime = 0.5f; 
    private float combatStateVolume = 0.1f;
     private float defaultStateVolume = 1.0f;
    private void Start(){
        audioSource.volume = 0f;
        audioSource.clip = ambienceSfxClip;
        audioSource.Play();
        FadeUpToVolume();
    }
    [ProButton]
    private void FadeUpToVolume(){
        AudioManager.Instance?.FadeAudioToVolume (audioSource, transitionTime, defaultStateVolume);

    }
     [ProButton]
    private void FadeDownToVolume(){
        AudioManager.Instance?.FadeAudioToVolume (audioSource, transitionTime, combatStateVolume);

    }
}
