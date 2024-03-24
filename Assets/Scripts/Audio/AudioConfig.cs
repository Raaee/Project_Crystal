using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This can honestly still be in the AudioManaager tbh
/// </summary>
public class AudioConfig : MonoBehaviour
{
    [SerializeField] private Transform customAudioSource3D;
    [SerializeField] private Transform altCustomAudioSource3D;

    public enum CustomAudioType //what are the 3d types we need? Crystal, Enemy, Projectile, 
    {
        NONE,
        Type1,
        Type2
    }

    //try to make this only get called on start or awake
    public Transform GetCustomAudioSource(CustomAudioType customAudioType, GameObject caller)
    {
        switch (customAudioType) //you can pass in the callers transform, just in case for any weird issue? can also make the caller send itself 
        {
            case CustomAudioType.Type1:
                var audioSource = Instantiate(customAudioSource3D, new Vector3(0, 0, 0), Quaternion.identity); // duplicated code refactor into a method
                audioSource.transform.parent = caller.transform;
                audioSource.transform.position = new Vector3(0, 0, 0); //localPosition or regular position?
                return audioSource;
            case CustomAudioType.Type2:
                return Instantiate(altCustomAudioSource3D, new Vector3(0, 0, 0), Quaternion.identity);
              
        }
        return null;
    }

}
