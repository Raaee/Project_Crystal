using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour  {

    // Var HP
    [Header("Player Health")]
    [SerializeField] private GameObject playerHPBar;
    [SerializeField] private Image hpFilling;
    [SerializeField] private TMP_Text hpText;

    // Var Mana
    [Header("Player Mana")]
    [SerializeField] private GameObject playerManaBar;
    [SerializeField] private Image manaFilling;
    [SerializeField] private TMP_Text manaText;

    // Var Teleport
    [Header("Teleport Ability")]
    [SerializeField] private Image teleportShadow;
    private float teleportTimer;
    private float teleportCooldown;

    // Var BasicAttack
    [Header("Basic Attack")]
    [SerializeField] private Image basicAttackShadow;
    private float basicAttackTimer;
    private float basicAttackCooldown;

    // Var PierceAttack
    [Header("Pierce Attack")]
    [SerializeField] private Image pierceAttackShadow;
    private float pierceAttackTimer;
    private float pierceAttackCooldown;

    // Var Crystal
    [Header("Crystal Health")]
    [SerializeField] private GameObject crystalHPBar;
    [SerializeField] private Image crystalHPFilling;
    [SerializeField] private TMP_Text crystalHPText;
    [SerializeField] private TMP_Text waveText;

    // Misc Var
    private bool hasListener = false;

    void Start()    {
      //  PlayerManager.Instance.teleport.OnAbilityUsage.AddListener(UpdateTeleportUI);
      //  PlayerManager.Instance.rangedBA.OnAbilityUsage.AddListener(UpdateBasicAttackUI);
      //  PlayerManager.Instance.pierceShot.OnAbilityUsage.AddListener(UpdatePierceUI);
        crystalHPFilling.fillAmount = 0;
        crystalHPText.text = "0";
        waveText.text = "No active wave";
        PlayerManager.Instance.hp.OnHealthChange.AddListener(UpdateHealth);
        PlayerManager.Instance.mp.OnManaChange.AddListener(UpdateMana);
        CrystalManager.Instance.OnCrystalActivate.AddListener(ActivateCrystalBars);
        CrystalManager.Instance.OnCrystalDeActivate.AddListener(DisactivateCrystalBars);

        crystalHPBar.SetActive(false);
        InitUI();
    } 
    public void InitUI() {
        teleportCooldown = PlayerManager.Instance.teleport.GetCooldownTime();
        basicAttackCooldown = PlayerManager.Instance.rangedBA.GetCooldownTime();
        pierceAttackCooldown = PlayerManager.Instance.pierceShot.GetCooldownTime();

        UpdateHealth();
        UpdateMana();
    }
    private void Update() {
        UpdateTeleportUI();
        UpdateBasicAttackUI();
        UpdatePierceUI();
        changeSpawnWave();
    }
    public void UpdateTeleportUI() {
        UpdateAbilityCooldown(PlayerManager.Instance.teleport, teleportCooldown, ref teleportTimer, teleportShadow);
    }
    public void UpdateBasicAttackUI() {
        UpdateAbilityCooldown(PlayerManager.Instance.rangedBA, basicAttackCooldown, ref basicAttackTimer, basicAttackShadow);
    }
    public void UpdatePierceUI() {
        UpdateAbilityCooldown(PlayerManager.Instance.pierceShot, pierceAttackCooldown, ref pierceAttackTimer, pierceAttackShadow);
    }
    public void UpdateHealth() {
        hpFilling.fillAmount = (float) PlayerManager.Instance.hp.GetCurrentHP() / PlayerManager.Instance.hp.GetMaxHealth();
        hpText.text = PlayerManager.Instance.hp.GetCurrentHP() + " / " + PlayerManager.Instance.hp.GetMaxHealth();
    }
    public void UpdateMana() {
        manaFilling.fillAmount = (float) PlayerManager.Instance.mp.currentMP / PlayerManager.Instance.mp.maxMP;
        manaText.text = PlayerManager.Instance.mp.currentMP + " / " + PlayerManager.Instance.mp.maxMP;
    }
    // Initial Set For The Crystal Bar
    public void ActivateCrystalBars(){
        
        CrystalManager.Instance.currentCrystalHP.OnHealthChange.AddListener(UpdateCrystalHP);
            
        crystalHPBar.SetActive(true);
        changeCrystalUI();
    }
    public void DisactivateCrystalBars() {
        crystalHPBar.SetActive(false);
    }
    // Update HP Info when enemy hits it
    public void UpdateCrystalHP(){
        changeCrystalUI();
    }
    // General Method To Change HP for The Crystal
    public void changeCrystalUI(){
        crystalHPFilling.fillAmount = (float) CrystalManager.Instance.currentCrystalHP.currentHP / CrystalManager.Instance.currentCrystalHP.maxHP;
        crystalHPText.text = CrystalManager.Instance.currentCrystalHP.currentHP + " / " + CrystalManager.Instance.currentCrystalHP.maxHP;
    }
    // Method To Change Waves Left
    public void changeSpawnWave(){
        if (CrystalManager.Instance.wave != null)
        {
            waveText.text = "Waves Left: " + CrystalManager.Instance.wave.waves.Count;
        }
    }

    // Updates Animation For The Abilities Boxes
    private void UpdateAbilityCooldown(Ability ability, float cooldown, ref float timer, Image shadow)  {
        if (ability.GetIsOnCooldown())  {
            timer += Time.deltaTime;
            shadow.fillAmount = Mathf.Clamp01(1 - (timer / cooldown));
        }
        else {
            timer = 0f;
            shadow.fillAmount = 0.0f;
        }
    }
}