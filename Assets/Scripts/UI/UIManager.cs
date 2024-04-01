using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour  {

    // var player stats
    [SerializeField] private PlayerHealthPoints playerHP;
    [SerializeField] private ManaPoints playerMP;

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
    [SerializeField] private TeleportAbility1 teleportAbility;
    [SerializeField] private Image teleportShadow;
    private float teleportTimer;
    private float teleportCooldown;

    // Var BasicAttack
    [Header("Basic Attack")]
    [SerializeField] private RangedBasicAttack basicAttack;
    [SerializeField] private Image basicAttackShadow;
    private float basicAttackTimer;
    private float basicAttackCooldown;

    // Var PierceAttack
    [Header("Pierce Attack")]
    [SerializeField] private PiercingShotAbility pierceAttack;
    [SerializeField] private Image pierceAttackShadow;
    private float pierceAttackTimer;
    private float pierceAttackCooldown; 


    void Start()    {
        teleportCooldown = teleportAbility.GetCooldownTime();
        basicAttackCooldown = basicAttack.GetCooldownTime();
        pierceAttackCooldown = pierceAttack.GetCooldownTime();
    }

    void Update()   {
        
        manaFilling.fillAmount = playerMP.GetCurrentMP() / 100f;
        manaText.text = playerMP.GetCurrentMP() + " / " + playerMP.GetMaxMP();

        hpFilling.fillAmount = playerHP.currentHP / 100f;
        hpText.text = playerHP.currentHP + " / " + playerHP.maxHP;
        
        // Teleport Box
        UpdateAbilityCooldown(teleportAbility, teleportCooldown, ref teleportTimer, teleportShadow);

        // PierceAttack Box
        UpdateAbilityCooldown(pierceAttack, pierceAttackCooldown, ref pierceAttackTimer, pierceAttackShadow);

        // RangedBasicAttack Box Currently Not Working
        UpdateAbilityCooldown(basicAttack, basicAttackCooldown, ref basicAttackTimer, basicAttackShadow);
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