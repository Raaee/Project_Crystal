using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour, IInteractable    {

    [SerializeField] private Material outlineMat;
    private Material normalMat;
    private SpriteRenderer sr;
    private BoxCollider2D bc2d;
    [SerializeField] private InteractableType interactableType;
    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        normalMat = sr.material;

        if (!this.gameObject.GetComponent<BoxCollider2D>()) {
            this.gameObject.AddComponent<BoxCollider2D>();
            bc2d = GetComponent<BoxCollider2D>();
        }
        bc2d.isTrigger = true;
    }

    public void Interact() {
        Debug.Log("Interacted.");
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
}
public enum InteractableType {
    HEALTH,
    MANA,
    BERSERK,
    CARROT,
    CHEST
}
