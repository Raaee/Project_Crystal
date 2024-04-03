using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalInteract : MonoBehaviour, IInteractable {

    [Header("Sprite Renderer Stuff")]
    [SerializeField] private Material outlineMat;
    private Material normalMat;
    private SpriteRenderer sr;
    private Spawner spawnerCrystal;
    public bool interactable = true;
    public bool Interactable { get => interactable; set => interactable = value; }

    private void Start() {
        sr = GetComponentInChildren<SpriteRenderer>();
        spawnerCrystal = GetComponent<Spawner>();
        normalMat = sr.material;
        spawnerCrystal.state = Spawner.State.Idle;
    }
    public void Interact() {
        if (Interactable) {
            spawnerCrystal.state = Spawner.State.Cooldown;
            Interactable = false;
        }        
    }
    public void HighlightSprite() {
        sr.material = outlineMat;
    }
    public void NormalSprite() {
        sr.material = normalMat;
    }
}
