using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour, IInteractable
{

    [SerializeField] private float dropChance;
    [SerializeField] private InteractableType interactableType;

    [Header("Sprite Renderer Stuff")]
    [SerializeField] private Material outlineMat;
    private Material normalMat;
    private SpriteRenderer sr;
    private BoxCollider2D bc2d;
    
    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        normalMat = sr.material;
        bc2d = GetComponent<BoxCollider2D>();
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
}
public enum InteractableType {
    HEALTH,
    MANA,
    BERSERK,
    CARROT,
    CHEST
}
