using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [Header("Player Health Audio")]
    [SerializeField] private AudioClip playerHurtClip;
    [SerializeField] private AudioClip playerDeathClip;
    [SerializeField] private AudioClip playerReviveClip;
    private AudioSource audioSource;

    [Header("Player Data")]
    [SerializeField] private PlayerHealthPoints playerHealth; 
    private void Start()
    {
        PlayReviveAudio();
        audioSource = GetComponent<AudioSource>();
        playerHealth.OnDead.AddListener(PlayDeathAudio);
        playerHealth.OnHurt.AddListener(PlayHurtAudio);
    }
    public void PlayDeathAudio()
    {
        
    }

    public void PlayReviveAudio()
    {

    }

    public void PlayHurtAudio()
    {

    }

    public void PlayTeleportAudio()
    {
        //teleport directions, left, right, mid left, mid right, and mid -> convert to panning 
    }
}
