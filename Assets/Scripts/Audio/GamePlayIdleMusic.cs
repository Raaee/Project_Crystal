using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.cyborgAssets.inspectorButtonPro;

public class GamePlayIdleMusic : MonoBehaviour
{
   
   [SerializeField] private AudioSource musicSource;

    [SerializeField] private AudioClip idleMusicClipA;
    [SerializeField] private AudioClip idleMusicClipB;
   
    [SerializeField][Range(0.01f,2f)] private float fadetime = 0.5f; 
   
     private float defaultStateVolume = 1.0f;
    private void Start(){
        musicSource.volume = 0f;
      //  musicSource.clip = idleMusicClip;
      DetermineMusicClip();
      StartCoroutine(WaitThenPlay());
    }
    [ProButton]
    private void FadeUpToVolume(){
        AudioManager.Instance?.FadeAudioToVolume (musicSource, fadetime, defaultStateVolume);

    }
    private void DetermineMusicClip(){
        musicSource.clip = idleMusicClipA;
    }
    public IEnumerator WaitThenPlay(){
        float randomNumber = Random.Range(0.5f,2f);
        yield return new WaitForSeconds(randomNumber);
        musicSource.Play();
        FadeUpToVolume();
    }
}
