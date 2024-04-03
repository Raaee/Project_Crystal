using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    // crystal class keeps track of all crystals in the map.
    // which are active and to change tiles after purification
    public static CrystalManager Instance { get; set; }
    [SerializeField] 
    private void Awake() {
        Init();
    }
    private void Init() {
        if (!Instance) {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }
}
