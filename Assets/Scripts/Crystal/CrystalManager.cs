using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrystalManager : MonoBehaviour
{
    // crystal class keeps track of all crystals in the map.
    // which are active and to change tiles after purification
    public static CrystalManager Instance { get; set; }
    public List<Crystal> crystals;
    private Crystal currentCrystal;
    [HideInInspector] public CrystalHealthPoints hp { get; set; }
    [HideInInspector] public Spawner wave { get; set; }
    [HideInInspector] public UnityEvent OnCrystalActivate;
    [HideInInspector] public UnityEvent OnCrystalDeActivate;
    private void Awake() {
        Init();        
    }

    public void SetCurrentCrystal(Crystal curr) {
        currentCrystal = curr;
    }

    public Crystal GetCurrentCrystal()
    {
        return currentCrystal;
    }
    public void SetCrystalComponents(Crystal curr){
        hp = curr.GetComponent<CrystalHealthPoints>();
        wave = curr.GetComponent<Spawner>();
        OnCrystalActivate.Invoke();
    }

    public void LockInteractions() {
        foreach(Crystal cryst in crystals) {
            if (!cryst.enabled || cryst == currentCrystal) continue;
            else {
                cryst.ChangeInteractionState(false);
            }
        }
    }
    // as purification numbers increase, purify radius also increases
    public void UnLockInteractions() {
        foreach (Crystal cryst in crystals) {
            if (cryst.CurrentState == CrystalState.IDLE) {
                cryst.ChangeInteractionState(true);
            }
        }
        OnCrystalDeActivate?.Invoke();
    
    }
    private void Init() {
        if (Instance) {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }

    public int GetCrystalsSavedAmount()
    {
        int i = 0;
        foreach(Crystal crystalInstance in crystals)
        {
            if (crystalInstance.CurrentState == CrystalState.PURIFIED)
                i++;
        }

        return i;
    }

}
