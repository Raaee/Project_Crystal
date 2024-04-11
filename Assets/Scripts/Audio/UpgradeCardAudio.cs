using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCardAudio : MonoBehaviour
{
   [SerializeField] private Upgrade upgradeCard;
   [SerializeField] private AudioSource audioSource;
   [SerializeField] private List<AudioClip> cardConfirmSounds;
   [SerializeField] private AudioClip selectCardSound;

   public void Start(){
    upgradeCard.OnCardConfirm.AddListener(PlayCardConfirmSound);
    upgradeCard.OnCardSelected.AddListener(PlaySelectSound);
   }

   public void PlayCardConfirmSound(){
    AudioClip cardConfirmSound = cardConfirmSounds[Random.Range(0, cardConfirmSounds.Count)];
        RandomizeAudio();

    AudioManager.Instance.PlayAudioOneShot(audioSource, cardConfirmSound);
   }
       private void RandomizeAudio()
    {
        audioSource.volume = Random.Range(0.75f, 0.99f);
        audioSource.pitch = Random.Range(0.95f, 1.05f);
    }
   public void PlaySelectSound(){
    AudioManager.Instance.PlayAudioOneShot(audioSource, selectCardSound);
   }
}
