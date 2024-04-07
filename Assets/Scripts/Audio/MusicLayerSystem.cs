using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using com.cyborgAssets.inspectorButtonPro;

/// <summary>
  /// A script that automatically spawns AudioSources based on the amount of AudioClips
  /// and creates a user controlled music system with layers. The public Methods of the system are
  /// Start
  /// Stop
  /// Increase Intensity
  /// Decrease Intensity
  /// Author: Peterson Normil petersonnormil@gmail.com
  /// </summary>
  
  public class MusicLayerSystem : MonoBehaviour
  {
    [Tooltip("the music clips you will place in, each clip is one layer")]
    [SerializeField] private AudioClip[] audioStems;
  
    [Tooltip("The time it takes to fade in for start and increasing intensity")]
    [SerializeField][Range(0.01f, 12f)] private float fadeInTime = 1.5f;
  
    [Tooltip("The time it takes to fade out for stop and decreasing intensity")]
    [SerializeField][Range(0.01f, 12f)] private float fadeOutTime = 1.5f;
  
    [Tooltip("If you are using the Unity Audio Mixer, this is where they will be routed to, else leave empty")]
    [SerializeField] private AudioMixerGroup musicMixerGroup; 
  
    //the AudioSources that will be playing the clips
    private AudioSource[] audioSources;
  
    //currentIntensity = 0 means the first music layer will play when you start the system
    private int currentIntensity;
  
    //helper variable to initialize the AudioSources 
    private int amountOfStems;
  
    //The max music volume, the fade in will go up to this value
    private const float MusicVolumeMax = 1f;
  
    //currently used as a way to stop multiple starts
    private bool musicSystemIsOn;

    private void Awake()
    {
      Init();
    }

 

    private void Init()
    {
      musicSystemIsOn = false;
      amountOfStems = audioStems.Length;

      if (amountOfStems <= 0)
      {
        Debug.LogWarning("No audio clips added to the audio stems!!");
        return; 
      }
      audioSources = new AudioSource[amountOfStems];
    
      for (int i = 0; i < amountOfStems; i++)
      {
        //spawn all the AudioSources
        AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
    
        //configure the audioSource properties 
        newAudioSource.playOnAwake = false;
        newAudioSource.loop = true;

        //assign clip to the audioSource
        newAudioSource.clip = audioStems[i];

        if(musicMixerGroup != null)
          newAudioSource.outputAudioMixerGroup = musicMixerGroup;
      
        //add to the audioSources array
        audioSources[i] = newAudioSource;
      }
    }
  
     [ProButton]
    public void StartMusicSystem()
    {
      //if music system already on, dont continue 
      if (musicSystemIsOn) return;
      musicSystemIsOn = true;
    
      audioSources[0].Play();
      //fade in first AudioSources
      StartCoroutine(FadeInMusicStem(audioSources[0],fadeInTime));

      for (int i = 1; i < audioSources.Length; i++)
      {
        audioSources[i].Play();
        audioSources[i].mute = true;
      }

      currentIntensity = 0;
    }
  
    
    /// <summary>
    /// Does a complete stop of the music system 
    /// </summary>
    [ProButton]
    public void StopMusicSystem()
    {
      if(!musicSystemIsOn) return;
    
      foreach (AudioSource musicSource in audioSources)
      {
        StartCoroutine(FadeOutMusicStem(musicSource, fadeOutTime));
      }

      StartCoroutine(StopAudioSourcesAfterElapsedTime());
    }
  
    /// <summary>
    /// helper method to stop all the audio sources after the fadeOutTime is finished
    /// </summary>
    private IEnumerator StopAudioSourcesAfterElapsedTime()
    {
      yield return new WaitForSeconds(fadeOutTime);
      foreach (AudioSource musicSource in audioSources)
      {
        musicSource.Stop();
      }
      musicSystemIsOn = false;
    }
  
    [ProButton]
    public void IncreaseIntensity()
    {
      if (!musicSystemIsOn) return;
    
      if (currentIntensity >= amountOfStems - 1)
      {
        Debug.LogWarning("MusicLayerSystem: Already reached highest intensity");
        return;
      }
      currentIntensity++;
      StartCoroutine(FadeInMusicStem(audioSources[currentIntensity], fadeInTime));
    
    }
  
  
     [ProButton]
    public void DecreaseIntensity()
    {
      if (!musicSystemIsOn) return;

      if (currentIntensity <= 0)
      {
        Debug.LogWarning("MusicLayerSystem: Already reached lowest intensity");
        return;
      }
      StartCoroutine(FadeOutMusicStem(audioSources[currentIntensity], fadeOutTime));
      currentIntensity--;
    }
  
  
  
    //instead of cluttering code, we use coroutine so its happening at a fixed frame rate,
    //and it uses less CPU cycles since the update function is happening every frame 
    private IEnumerator FadeInMusicStem(AudioSource activeSource, float transitionTime)
    {
      activeSource.volume = 0.0f;
      activeSource.mute = false;

      for (float t = 0.0f; t <= transitionTime; t += Time.deltaTime)
      {
        activeSource.volume = (t / transitionTime) * MusicVolumeMax;
        yield return null;
      }

      activeSource.volume = MusicVolumeMax; 

    }

    private IEnumerator FadeOutMusicStem(AudioSource activeSource, float transitionTime)
    {

      for (float t = 0.0f; t <= transitionTime; t += Time.deltaTime)
      {
        activeSource.volume = (MusicVolumeMax -((t / transitionTime) * MusicVolumeMax));
        yield return null;
      }
      activeSource.mute = true;

      activeSource.volume = MusicVolumeMax;
    }

    /*
    //Testing, comment out or delete when not in use 
    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Q))
      {
        StartMusicSystem();
      }
    
      if (Input.GetKeyDown(KeyCode.W))
      {
        IncreaseIntensity();
      }
    
      if (Input.GetKeyDown(KeyCode.E))
      {
        DecreaseIntensity();
      }
    
      if (Input.GetKeyDown(KeyCode.R))
      {
        StopMusicSystem();
      }
    
    }
    
    */
  }