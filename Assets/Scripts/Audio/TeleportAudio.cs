using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAudio : MonoBehaviour
{
    [SerializeField] private AudioSource teleportAudioSource;
    [SerializeField] private List<AudioClip> teleportAudioClips;
    [SerializeField] private TeleportAbility teleportAbility;

    private void Start()
    {
        teleportAbility.OnTeleport.AddListener(PlayTeleportAudio);
    }
    public void PlayTeleportAudio(Vector2 newMovementInput)
    {
        int num = Random.Range(0, teleportAudioClips.Count);

       HandlePanAudio(newMovementInput);

        teleportAudioSource.PlayOneShot(teleportAudioClips[num]);
    }

    private void HandlePanAudio(Vector2 newMovementInput)
    {
        if(newMovementInput.x == -1)
        {
            //full left
            teleportAudioSource.panStereo = -0.5f;
        }

        if (newMovementInput.x == 1)
        {
            //full right
            teleportAudioSource.panStereo = 0.5f;
        }

        if (newMovementInput.x > 0 && newMovementInput.x < 1)
        {
            //mid left
            teleportAudioSource.panStereo = 0.25f;
        }

        if (newMovementInput.x < 0 && newMovementInput.x > -1)
        {
            //mid right
           
            teleportAudioSource.panStereo = -0.25f;
        }

        if (newMovementInput.x == 0)
        {
            //mid
            teleportAudioSource.panStereo = 0;
        }

        
    }



}
