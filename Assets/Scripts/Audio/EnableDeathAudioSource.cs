using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDeathAudioSource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       var playerObj = PlayerManager.Instance.GetPlayer();
        playerObj.GetComponent<PlayerHealthPoints>().OnDead.AddListener(AddAudioListener);
    }

    private void AddAudioListener()
    {
        AudioListener audioListner = gameObject.AddComponent<AudioListener>();
    }

   
}
