using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The ambience system will play a looping bed of audio throughout the idle gameplay state. and then will have lower audio during crystal wave states.
/// The "default" audio volume will be set in the audio mixer
/// </summary>
/// 
//make sure to set an audio mixer just for ambience
public class AmbienceAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ambienceSfxClip;
   private float combatStateVolume = 0.125f;
    [SerializeField] [Range(0.01f, 1.5f)] private float transitionTime = 0.5f;
    private void Start()
    {
        //set volume to zero
        audioSource.volume = 0f;

        //set audio clip
        audioSource.clip = ambienceSfxClip;

        //play 
        audioSource.Play();

        //play with a subtle fade in
        FadeUpToValue();
    }


    [ProButton]
    private void FadeOutToValue()
    {
        //StartCoroutine(FadeOutAudioStem(audioSource, transitionTime, combatStateVolume));
        AudioManager.Instance?.FadeAudioToVolume(audioSource, transitionTime, combatStateVolume);
    }

    [ProButton]
    private void FadeUpToValue()
    {
        //StartCoroutine(FadeInAudioStem(audioSource, transitionTime, 1f));
        AudioManager.Instance?.FadeAudioToVolume(audioSource, transitionTime, 1f);
    }

}
