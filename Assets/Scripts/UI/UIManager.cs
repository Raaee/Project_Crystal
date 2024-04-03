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

    void Start()    {
      //  PlayerManager.Instance.teleport.OnAbilityUsage.AddListener(UpdateTeleportUI);
      //  PlayerManager.Instance.rangedBA.OnAbilityUsage.AddListener(UpdateBasicAttackUI);
      //  PlayerManager.Instance.pierceShot.OnAbilityUsage.AddListener(UpdatePierceUI);
        PlayerManager.Instance.hp.OnHealthChange.AddListener(UpdateHealth);
        PlayerManager.Instance.mp.OnManaChange.AddListener(UpdateMana);
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
        hpFilling.fillAmount = PlayerManager.Instance.hp.currentHP / 100f;
        hpText.text = PlayerManager.Instance.hp.currentHP + " / " + PlayerManager.Instance.hp.maxHP;
    }
    public void UpdateMana() {
        manaFilling.fillAmount = PlayerManager.Instance.mp.currentMP / 100f;
        manaText.text = PlayerManager.Instance.mp.currentMP + " / " + PlayerManager.Instance.mp.maxMP;
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