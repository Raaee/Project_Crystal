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
    [HideInInspector] public CrystalHealthPoints currentCrystalHP { get; set; }
    [HideInInspector] public Spawner wave { get; set; }
    [HideInInspector] public UnityEvent OnCrystalActivate;
    [HideInInspector] public UnityEvent OnCrystalDeActivate;
    [HideInInspector] public UnityEvent OnAllCrystalsComplete;
    [field: SerializeField] public int CrystalsPurified { get; set; } // this is for winning

    [SerializeField] private Transform bossCrystalLoc;
    private Crystal bossCrystal;
    private const string BOSS_CRYSTAL_TAG = "BossCrystal"; // Tag used to identify the boss crystal.

    private void Awake() {
        CrystalsPurified = 0;
        Init();        
    }
    private void Start() {
        bossCrystal = FindBossCrystal();
    }
    public void SetCurrentCrystal(Crystal curr) {
        currentCrystal = curr;
    }

    public Crystal GetCurrentCrystal()
    {
        return currentCrystal;
    }
    public void SetCrystalComponents(Crystal curr){
        currentCrystalHP = curr.GetComponent<CrystalHealthPoints>();
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
    public void UnLockInteractions() {
        foreach (Crystal cryst in crystals) {
            if (cryst.CurrentState == CrystalState.IDLE) {
                cryst.ChangeInteractionState(true);
            }
        }
        OnCrystalDeActivate?.Invoke();

        if (CrystalsPurified == crystals.Count-2) {
            Debug.Log("BEGIN THE FINAL TEST");
            bossCrystal.UpdateOriginalYPos(bossCrystalLoc.position.y);
            bossCrystal.gameObject.transform.position = bossCrystalLoc.position;
        }
        if (bossCrystal.CurrentState == CrystalState.PURIFIED) {
            OnAllCrystalsComplete?.Invoke();
        }
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
    public Crystal FindBossCrystal() {
        foreach (Crystal cryst in crystals) {
            if (cryst.gameObject.CompareTag(BOSS_CRYSTAL_TAG)) {
                return cryst;
            }
        }
        Debug.Log("Missing Boss Crystal", gameObject);
        return null;
    }

}
