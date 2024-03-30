using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAudio : MonoBehaviour
{
    [SerializeField] private AudioSource teleportAudioSource;
    [SerializeField] private List<AudioClip> teleportAudioClips;
    [SerializeField] private TeleportAbility1 teleportAbility;

    private void Start()
    {
        teleportAbility.OnTeleport.AddListener(PlayTeleportAudio);
    }
    public void PlayTeleportAudio(Vector2 newMovementInput)
    {
        int num = Random.Range(0, teleportAudioClips.Count);
        teleportAudioSource.PlayOneShot(teleportAudioClips[num]);
    }
}
