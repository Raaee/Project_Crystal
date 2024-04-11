using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvent : MonoBehaviour
{
    [SerializeField] private PlayerAudio playerAudio;
    public void AudioOnPlayerDead(){
        playerAudio.PlayDeathAudio();
    }
    public void AudioOnPlayerRespawn(){
        playerAudio.PlayReviveAudio();
    }
}
