using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private Projectile projectile;
    private float fadeOutTime = 0.5f;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        projectile = GetComponentInParent<Projectile>();

        projectile.OnProjectileDisabled.AddListener(PopOutAudio);
    }


    public void PopOutAudio()
    {
        StartCoroutine(FadeAudio(fadeOutTime));
        StartCoroutine(HandlePopOutAudio());
       
        
    }

    private IEnumerator HandlePopOutAudio()
    {
        //pop out from the parent object 
        this.gameObject.transform.parent = null;
        //fade out sound 
        yield return new WaitForSeconds(0.5f);
        //die after a short delay
        Destroy(this.gameObject);
    }

    private IEnumerator FadeAudio( float transitionTime)
    {
        float currentVolume = audioSource.volume;
        for (float T = 0.0f; T <= transitionTime; T += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(currentVolume, 0.01f, T / transitionTime);
            yield return null;
        }
        audioSource.volume = 0.01f;
    }
}
