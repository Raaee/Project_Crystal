using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Var Player and Abilities
    private GameObject player;
    private GameObject abilities;
    // Var HP
    private GameObject playerHPBar;
    private Image hpFilling;
    private TMP_Text hpText;
    // Var Mana
    private GameObject playerManaBar;
    private Image manaFilling;
    private TMP_Text manaText;
    // Var Teleport
    private GameObject teleportObject;
    private Image teleportShadow;
    private float teleportTimer;
    private float teleportCooldown;
    // Var PierceAttack
    private GameObject pierceAttackObject;
    private Image pierceAttackShadow;
    private float pierceAttackTimer;
    private float pierceAttackCooldown;
    // Var BasicAttack
    private GameObject basicAttackObject;
    private Image basicAttackShadow;
    private float basicAttackTimer;
    private float basicAttackCooldown;


    void Start()
    {
        //Access to HP Bar
        playerHPBar = transform.Find("HPBar").gameObject;
        hpFilling = playerHPBar.transform.GetChild(1).GetComponent<Image>();
        hpText = playerHPBar.transform.GetChild(2).GetComponent<TMP_Text>();
        // Access to MP Bar
        playerManaBar = transform.Find("MPBar").gameObject;
        manaFilling = playerManaBar.transform.GetChild(1).GetComponent<Image>();
        manaText = playerManaBar.transform.GetChild(2).GetComponent<TMP_Text>();
        // Access To Player and Abilities
        player = GameObject.FindGameObjectWithTag("Player");
        abilities = GameObject.Find("Abilities");
        // Access To Teleport Object
        teleportObject = transform.Find("TeleportBars").gameObject;
        teleportShadow = teleportObject.transform.GetChild(2).GetComponent<Image>();
        teleportCooldown = abilities.GetComponent<TeleportAbility1>().getCooldownTime();
        // Access To Pierce Attack
        pierceAttackObject = transform.Find("PierceAttackBars").gameObject;
        pierceAttackShadow = pierceAttackObject.transform.GetChild(2).GetComponent<Image>();
        pierceAttackCooldown = abilities.GetComponent<PiercingShotAbility>().getCooldownTime();
        // Access To Basic Attack Currently Not Working
        // basicAttackObject = transform.Find("BasicAttackBars").gameObject;
        // basicAttackShadow = basicAttackObject.transform.GetChild(2).GetComponent<Image>();
        // basicAttackCooldown = abilities.GetComponent<RangedBasicAttack>().getPlayerFireRate();
    }

    void Update()
    {
        if (player != null)
        {
            // Mana Bar
            if (playerManaBar != null)
            {
                manaFilling.fillAmount = player.GetComponent<ManaPoints>().GetCurrentMP() / 100f;
                manaText.text = "MP: " + player.GetComponent<ManaPoints>().GetCurrentMP();
            }

            // HP Bar
            if (playerHPBar != null)
            {
                hpFilling.fillAmount = player.GetComponent<PlayerHealthPoints>().GetCurrentHP() / 100f;
                hpText.text = "HP: " + player.GetComponent<PlayerHealthPoints>().GetCurrentHP();
            }

            // Teleport Box
            UpdateAbilityCooldown(abilities.GetComponent<TeleportAbility1>(), teleportCooldown, ref teleportTimer, teleportShadow);

            // PierceAttack Box
            UpdateAbilityCooldown(abilities.GetComponent<PiercingShotAbility>(), pierceAttackCooldown, ref pierceAttackTimer, pierceAttackShadow);

            // RangedBasicAttack Box Currently Not Working
            // UpdateAbilityCooldown(abilities.GetComponent<RangedBasicAttack>(), basicAttackCooldown, ref basicAttackTimer, basicAttackShadow);
        }
    }

    // Updates Animation For The Abilities Boxes
    void UpdateAbilityCooldown(Ability ability, float cooldown, ref float timer, Image shadow)
        {
            if (ability.getCooldown())
                {
                    timer += Time.deltaTime;
                    shadow.fillAmount = Mathf.Clamp01(1 - (timer / cooldown));
                }
            else
                {
                    timer = 0f;
                    shadow.fillAmount = 0.0f;
                }
        }


    }