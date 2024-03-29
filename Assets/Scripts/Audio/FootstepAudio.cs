using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    private float stepRate = 0.33f;
    private float stepCoolDown;
    public List<AudioClip> footSteps;
    [SerializeField] private AudioSource audioSource;




    // Update is called once per frame
    void Update()
    {
        stepCoolDown -= Time.deltaTime;
        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f)// instead of input check velocity
        {
            audioSource.pitch = 1f + Random.Range(-0.2f, 0.2f);
            audioSource.PlayOneShot(ChooseRandomFootstep(footSteps), 0.05f);
            stepCoolDown = stepRate;
        }
    }



    public AudioClip ChooseRandomFootstep(List<AudioClip> footsteps)
    {
        int num = Random.Range(0, footsteps.Count);
        return footsteps[num];
    }
}
