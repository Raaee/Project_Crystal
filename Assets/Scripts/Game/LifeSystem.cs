using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LifeSystem : MonoBehaviour {

    [field: SerializeField] public int MaxLives { get; private set; }
    public int CurrentLives { get; set; }

    [HideInInspector] public UnityEvent OnRemoveLife;

    private void Start() {
        MaxLives = 3;

        var crystals = CrystalManager.Instance.crystals;
        foreach (Crystal crystal in crystals) {
            crystal.OnCrystalDie.AddListener(RemoveLife);
        }

        PlayerManager.Instance.hp.OnDead.AddListener(RemoveLife);
    }

    public void RemoveLife() {
        OnRemoveLife.Invoke();
    }
    public void LifeDone() {
        SceneManager.LoadScene(1); // instant reload of scene
    }
}
