using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour, IInteractable
{

    [Header("Drop Configs")]
    [SerializeField] private float dropChance = 0.1f;
    [SerializeField] private InteractableType interactableType;

    [Header("Outline Configs")]
    [SerializeField] private Material outlineMat;
    private Material normalMat;
    private SpriteRenderer sr;
    private BoxCollider2D bc2d;

    [Header("Audio  Configs")]
    [SerializeField] private AudioClip dropInteractSfxClip;
    private AudioSource dropAudioSource;
  

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        normalMat = sr.material;
        bc2d = GetComponent<BoxCollider2D>();
        dropAudioSource = GetComponent<AudioSource>();
       // bc2d.isTrigger = true;
    }

    public void Interact() {
       // Debug.Log("Interacted.");
        if (ItemCollector.instance == null)
        {
            Debug.Log("Item Collector is Null.");
        }
        ItemCollector.instance.Interact(interactableType, this.gameObject);
        NormalSprite();
        HandleDropAudio();
       // Destroy(this.gameObject);
    }

  

    public void HighlightSprite() {
        sr.material = outlineMat;
    }

    public void NormalSprite() {
        sr.material = normalMat;
    }
    public InteractableType GetInteractableType() {
        return interactableType;
    }
    public float GetDropChance() {
        return dropChance;
    }

    private void HandleDropAudio()
    {
        if (!dropInteractSfxClip)
            return;
        AudioManager.Instance?.PlayAudioOneShot(dropAudioSource, dropInteractSfxClip);
    }
}
public enum InteractableType {
    HEALTH,
    MANA,
    BERSERK,
    CARROT,
    CHEST
}
