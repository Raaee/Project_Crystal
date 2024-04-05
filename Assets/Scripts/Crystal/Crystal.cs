using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour { 

    private Spawner spawner;
    private CrystalVFX crystalVFX;
    private CrystalHealthPoints hp;
    private CrystalInteract crystalInteract;

    [Header("Debug")]
    [SerializeField] private CrystalState currentState;

    public CrystalState CurrentState { get => currentState; set => currentState = value; }

    private void Start() {
        spawner = GetComponent<Spawner>();
        crystalVFX = GetComponent<CrystalVFX>();
        hp = GetComponent<CrystalHealthPoints>();
        crystalInteract = GetComponent<CrystalInteract>();
        currentState = CrystalState.IDLE;
        spawner.OnSpawnerStart.AddListener(OnCrystalEngaing);
        spawner.OnSpawnerComplete.AddListener(OnCrystalComplete);
        hp.OnDead.AddListener(OnCrystalDeath);
    }
    public void OnCrystalComplete() {
        currentState = CrystalState.PURIFIED;
        PurifyInRadius();
        CrystalManager.Instance.UnLockInteractions();
    }
    public void OnCrystalDeath() {
        currentState = CrystalState.SHATTERED;
        CrystalManager.Instance.UnLockInteractions();
        // visual using VFX
        // SFX
        // lose a life
    }
    private void OnCrystalEngaing() {
        currentState = CrystalState.ENGAGING;
        CrystalManager.Instance.SetCurrentCrystal(this);
        CrystalManager.Instance.SetCrystalComponents(this);
        CrystalManager.Instance.LockInteractions();
    }
    public void PurifyInRadius() {
        TilePurificationManager.instance?.PurifyInRadius(this.gameObject.transform, (int)(spawner.radius * 1.25));
        crystalVFX.ActivatePurifiedParticles();
        crystalVFX.PurifySprite();
    }
    public void ChangeInteractionState(bool interactable) {
        crystalInteract.Interactable = interactable;
    }

}
public enum CrystalState {
    IDLE,
    ENGAGING,
    SHATTERED,
    PURIFIED
}

