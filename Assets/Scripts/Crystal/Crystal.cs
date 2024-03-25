using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour, IInteractable {

    [Header("Sprite Renderer Stuff")]
    [SerializeField] private Material outlineMat;
    private Material normalMat;
    private SpriteRenderer sr;
    private Spawner spawnerCrystal;

    private void Start() {
        sr = GetComponentInChildren<SpriteRenderer>();
        spawnerCrystal = GetComponent<Spawner>();
        normalMat = sr.material;
        spawnerCrystal.state = Spawner.State.Idle;
    }
    public void Interact() {
        Debug.Log("crystal  interaction");
        spawnerCrystal.state = Spawner.State.Cooldown;
        this.enabled = false;
    }
    public void HighlightSprite() {
        sr.material = outlineMat;
    }
    public void NormalSprite() {
        sr.material = normalMat;
    }
}
