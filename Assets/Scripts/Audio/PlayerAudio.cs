using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [Header("Player Health Audio")]
    [SerializeField] private List<AudioClip> playerHurtClips;
    [SerializeField] private AudioClip playerDeathClip;
    [SerializeField] private AudioClip playerReviveClip;
    private AudioSource audioSource;

    [Header("Player Data")]
    [SerializeField] private PlayerHealthPoints playerHealth; 
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerHealth.OnHurt.AddListener(PlayHurtAudio);
    }
    public void PlayDeathAudio()
    {
        audioSource.PlayOneShot(playerDeathClip);
    }

    public void PlayReviveAudio()
    {
         audioSource.PlayOneShot(playerReviveClip);
    }

    public void PlayHurtAudio()
    {
        AudioClip playerHurt = playerHurtClips[Random.Range(0, playerHurtClips.Count)];
        RandomizeAudio();
        audioSource.PlayOneShot(playerHurt);

    }

    private void RandomizeAudio()
    {
        audioSource.volume = Random.Range(0.75f, 0.99f);
        audioSource.pitch = Random.Range(0.95f, 1.05f);
    }


}
