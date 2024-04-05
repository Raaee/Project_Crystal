using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalAudio : MonoBehaviour
{
  [SerializeField] private AudioSource audioSource;
  [SerializeField] private AudioClip crystalDeathClip;
  [SerializeField] private AudioClip startWaveStinger;
  public void PlayCrystalDeath(){
    
  AudioManager.Instance.PlayAudioOneShot(audioSource, crystalDeathClip);

  }
  public void PlayStartWaveStinger(){
  AudioManager.Instance.PlayAudioOneShot(audioSource, startWaveStinger);

  }
}
