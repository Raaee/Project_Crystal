using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour {

    [SerializeField] private GameObject player;
    public static PlayerManager Instance { get; set; }
    [HideInInspector] public PlayerHealthPoints hp { get; set; }
    [HideInInspector] public ManaPoints mp { get; set; }
    [HideInInspector] public RangedBasicAttack rangedBA { get; set; }
    [HideInInspector] public PiercingShotAbility pierceShot { get; set; }
    [HideInInspector] public TeleportAbility teleport { get; set; }


    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject reviveParticles;
    [SerializeField] string reviveParticleGOName;
    [SerializeField] private float reviveTime = 1f;
    private GameObject deathPanelClone;

    private InputControls input;
    [HideInInspector] public UnityEvent OnRevive;

    // Animation
    private Animator animator;
    private const string DEATH = "Death";
    private const string RESPAWN = "Respawn";

    void Awake() {
        Init();
     
    }
    private void Start() {
        Components();
        hp.OnDead.AddListener(Death);
        reviveParticles.SetActive(false);
        Respawn();
    }
    public void Components() {
        input = player.GetComponent<InputControls>();
        hp = player.GetComponent<PlayerHealthPoints>();
        mp = player.GetComponent<ManaPoints>();
        animator = player.GetComponentInChildren<Animator>();
        rangedBA = player.GetComponentInChildren<RangedBasicAttack>();
        pierceShot = player.GetComponentInChildren<PiercingShotAbility>();
        teleport = player.GetComponentInChildren<TeleportAbility>();
        reviveParticles = player.transform.Find(reviveParticleGOName).gameObject; // Dont worry about it.
    }
    public void Death() {
     
        animator.Play(DEATH);
        deathPanelClone = Instantiate(deathPanel);
        StartCoroutine(WaitBeforeDisable());
        // input.DisableControls();
        // lose a life
    }
    [ProButton]
    public void Respawn() {
        player.transform.position = spawnPoint.transform.position;
        player.SetActive(true);
        StartCoroutine(Revive());
        animator.Play(RESPAWN);
        // input.EnableControls();
        hp.ResetHealth();
        mp.ResetMana();
    }
    public IEnumerator WaitBeforeDisable() {
        yield return new WaitForSeconds(reviveTime);
        DisablePlayer();
    }
    public void DisablePlayer() {
        player.gameObject.SetActive(false);
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
    public void SetPlayer(GameObject prefab) {
        player = prefab;
    }
    public void SetSpawnPoint(Transform loc) {
        spawnPoint = loc;
    }
    public GameObject GetPlayer() {
        return player;
    }
    public void DestoryDeathPanel()
    {
        
        Destroy(deathPanelClone);
    }
}
