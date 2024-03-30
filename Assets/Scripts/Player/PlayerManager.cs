using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; set; }
    [SerializeField] private GameObject reviveParticles;
    [SerializeField] private float reviveTime = 1f;
    private PlayerHealthPoints hp;
    private ManaPoints mp;
    private InputControls input;
    [HideInInspector] public UnityEvent OnRevive;
    
    // Animation
    private Animator animator;
    private const string DEATH = "Death";
    private const string DOWN_WALK = "Down Walk";
    private const string RESPAWN = "Respawn";

    private void Start() {
        Init();
        input = GetComponent<InputControls>();
        hp = GetComponent<PlayerHealthPoints>();
        mp = GetComponent<ManaPoints>();
        animator = GetComponentInChildren<Animator>();
        hp.OnDead.AddListener(Death);
        reviveParticles.SetActive(false);
    }
    public void Death() {
        Debug.Log("dieeeeeeee");
        animator.Play(DEATH);
       // input.DisableControls();
        DisablePlayer();
    }
    [ProButton]
    public void Respawn() {
        this.gameObject.SetActive(true);
        StartCoroutine(Revive());
        animator.Play(RESPAWN);
       // input.EnableControls();
        hp.ResetHealth();
        mp.ResetMana();
    }
    public void DisablePlayer() {
        this.gameObject.SetActive(false);
    }
    public IEnumerator Revive() {
        reviveParticles.SetActive(true);
        yield return new WaitForSeconds(reviveTime);
        reviveParticles.SetActive(false);
    }

    public void Init() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }

}
