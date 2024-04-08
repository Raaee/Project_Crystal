using com.cyborgAssets.inspectorButtonPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crystal : MonoBehaviour {

    private Spawner spawner;
    private CrystalVFX crystalVFX;
    private CrystalHealthPoints hp;
    private CrystalInteract crystalInteract;
    [SerializeField] private float percentBlast;
    [HideInInspector] public UnityEvent OnCrystalDie;

    [Header("Debug")]
    [SerializeField] private CrystalState currentState;

    public CrystalState CurrentState { get => currentState; set => currentState = value; }

    public UnityEvent _OnNextWaveStarted;

    private void Start() {
        spawner = GetComponent<Spawner>();
        crystalVFX = GetComponent<CrystalVFX>();
        hp = GetComponent<CrystalHealthPoints>();
        crystalInteract = GetComponent<CrystalInteract>();
        currentState = CrystalState.IDLE;
        spawner.OnSpawnerStart.AddListener(OnCrystalEngaing);
        spawner.OnSpawnerComplete.AddListener(OnCrystalComplete);
        spawner.OnNextWaveStarted.AddListener(CrystalOnNextWaveStarted);
        hp.OnDead.AddListener(OnCrystalDeath);

        DamageBlast();
    }

    private void CrystalOnNextWaveStarted()
    {
        _OnNextWaveStarted?.Invoke();
    }

    public void OnCrystalComplete() {
        if(currentState == CrystalState.SHATTERED) return;
        currentState = CrystalState.PURIFIED;
        UpgradeMenu.instance.gameObject.SetActive(true);
        PurifyInRadius();
        CrystalManager.Instance.UnLockInteractions();
    }
    public void OnCrystalDeath() {
        if(currentState == CrystalState.SHATTERED || currentState == CrystalState.PURIFIED) return;
        currentState = CrystalState.SHATTERED;
        CrystalManager.Instance.UnLockInteractions();
        spawner.state = Spawner.State.Idle;
        OnCrystalDie.Invoke();
        // visual using VFX
        // SFX
        // lose a life
    }
    private void OnCrystalEngaing() {
        if(currentState == CrystalState.SHATTERED || currentState == CrystalState.PURIFIED) return;
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

    public void DamageBlast() {
        float percentHP = Mathf.RoundToInt(hp.GetCurrentHP() * percentBlast);
        //Debug.Log(hp.GetCurrentHP());
        //Debug.Log(percentHP);
    }

}
public enum CrystalState {
    IDLE,
    ENGAGING,
    SHATTERED,
    PURIFIED
}

