using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("more than one AudioManager in Scene");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void FadeAudioToVolume(AudioSource activeSource, float transitionTime, float targetVolume)
    {
        StartCoroutine(FadeAudio(activeSource, transitionTime, targetVolume));
    }


    private IEnumerator FadeAudio(AudioSource activeSource, float transitionTime, float targetVolume)
    {
       

        float currentVol = activeSource.volume;
        for (float t = 0.0f; t <= transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = Mathf.Lerp(currentVol, targetVolume, t / transitionTime);
            yield return null;
        }

        activeSource.volume = targetVolume;

    }

}
