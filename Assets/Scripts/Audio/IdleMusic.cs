using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// will play one of 2 msuic clips once base on current progression of game. will fade out if needed due to a battle sequence
/// </summary>
public class IdleMusic : MonoBehaviour
{
    [SerializeField] private AudioClip idleMusicA;
    [SerializeField] private AudioClip idleMusicB;
    [SerializeField] private AudioSource audioSource;
    private const float DELAY_RANGE = 4f;
    private const float FADE_OUT_TIME = 4f;

    [Header("DEBUG")]
    [SerializeField] private bool playerHasEvolved = false;

    [ProButton]
    private void Start()
    {
        StartCoroutine(StartPlayRandomDelay());
    }

    private IEnumerator StartPlayRandomDelay()
    {
        //method to check progress and assign clip
        SetClip();

     
        float randomDelay = Random.Range(0.01f, DELAY_RANGE);
        yield return new WaitForSeconds(randomDelay);

        audioSource.volume = 0;
        audioSource.Play();
        AudioManager.Instance?.FadeAudioToVolume(audioSource, 0.01f, 1.0f);
    }

    private void SetClip()
    {
        //grab the info about the player progress and set clip

        audioSource.clip = playerHasEvolved ? idleMusicB : idleMusicA;

    }


    [ProButton]
    private void FadeOut()
    {
        AudioManager.Instance?.FadeAudioToVolume(audioSource, FADE_OUT_TIME, 0.0f);
    }

  
}
