using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    // crystal class keeps track of all crystals in the map.
    // which are active and to change tiles after purification
    public static CrystalManager Instance { get; set; }
    public List<Crystal> crystals;
    private Crystal currentCrystal;

    private void Awake() {
        Init();        
    }
    public void SetCurrentCrystal(Crystal curr) {
        currentCrystal = curr;
    }
    public void LockInteractions() {
        foreach(Crystal cryst in crystals) {
            if (cryst == currentCrystal) continue;
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
    }
    private void Init() {
        if (Instance) {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }
}
