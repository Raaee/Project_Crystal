using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrystalAudio : MonoBehaviour
{
  [SerializeField] private Crystal crystal; 
  [SerializeField] private AudioSource audioSource;
  [SerializeField] private AudioClip crystalDeathClip;
  [SerializeField] private AudioClip startWaveStinger;

  private void Start(){
  //crystal.OnCrystalDeathEvent.AddListener(PlayCrystalDeath);

  }
  public void PlayCrystalDeath(){

  AudioManager.Instance.PlayAudioOneShot(audioSource, crystalDeathClip);

  }
  public void PlayStartWaveStinger(){
  AudioManager.Instance.PlayAudioOneShot(audioSource, startWaveStinger);

  }
}
