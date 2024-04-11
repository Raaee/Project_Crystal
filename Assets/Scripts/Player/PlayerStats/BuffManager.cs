using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class BuffManager : MonoBehaviour  {

    // Singleton pattern
    public static BuffManager instance;

   
    private GameObject playerPrefab;
    // Player Stats
    private PlayerHealthPoints playerHealth;
    private ManaPoints playerMana;
    private PlayerMovement playerMovement;

    // Abilities
    private TeleportAbility teleportAbility;
    private RangedBasicAttack basicAttack;
    private PiercingShotAbility piercingShot;
    // Health

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    private void Start() {
        playerPrefab = PlayerManager.Instance.GetPlayer();

        playerHealth = playerPrefab.GetComponent<PlayerHealthPoints>();
        playerMana = playerPrefab.GetComponent<ManaPoints>();
        playerMovement = playerPrefab.GetComponent<PlayerMovement>();
        teleportAbility = playerPrefab.GetComponentInChildren<TeleportAbility>();
        basicAttack = playerPrefab.GetComponentInChildren<RangedBasicAttack>();
        piercingShot = playerPrefab.GetComponentInChildren<PiercingShotAbility>();
    }
    public void AddHealth(int amt) {
        playerHealth.AddHealth(amt);
    }
    public void IncreaseMaxHealth(float percentageIncrease) {
        int maxHP = playerHealth.GetMaxHealth();
        playerHealth.SetMaxHealth(maxHP + (int)(maxHP * percentageIncrease));
    }
    // Mana
    public void AddMana(int amt) {
        playerMana.AddMana(amt);
    }
    public void IncreaseMaxMana(float percentageIncrease) {
        float maxMP = playerMana.GetMaxMana();
        playerMana.SetMaxMana(maxMP + (maxMP * percentageIncrease));
    }    
    // Basic Attack
    public void IncreaseMaxBasicAttackDamage(float percentageIncrease) {
        int damage = basicAttack.GetMaxProjectileDamage();
        basicAttack.SetMaxProjectileDamage(damage + (int)(damage * percentageIncrease));
    }
    // Pierce Shot
    public void IncreaseMaxPierceShotDamage(float percentageIncrease) {
        int damage = piercingShot.GetMaxDamage();
        piercingShot.SetMaxDamage(damage + (int)(damage * percentageIncrease));
    }
    // Cooldown Reductions
    public void ReduceBasicAttackCooldown(float percentageDecrease) {
        basicAttack.SetPlayerFireRate(basicAttack.GetPlayerFireRate() - (basicAttack.GetPlayerFireRate() * percentageDecrease));
    }
    public void ReduceTeleportCooldown(float percentageDecrease) {
        teleportAbility.SetCooldown(teleportAbility.GetCooldownTime() - (teleportAbility.GetCooldownTime() * percentageDecrease));
    }
    public void ReducePierceShotCooldown(float percentageDecrease) {
        piercingShot.SetCooldown(piercingShot.GetCooldownTime() - (piercingShot.GetCooldownTime() * percentageDecrease));
    }
    public void ReduceAllAbilityCooldowns(float percentageDecrease) {
        ReduceBasicAttackCooldown(percentageDecrease);
        ReduceTeleportCooldown(percentageDecrease);
        ReducePierceShotCooldown(percentageDecrease);
    }
    public void ReduceAllManaCost(float percentageDecrease) {
        ReduceBasicAttackManaCost(percentageDecrease);
        ReduceTeleportManaCost(percentageDecrease);
        ReducePierceShotManaCost(percentageDecrease);
    }
    public void ReduceBasicAttackManaCost(float percentageDecrease) {
        basicAttack.SetManaCost(basicAttack.GetManaCost() - (basicAttack.GetManaCost() * percentageDecrease));
    }
    public void ReduceTeleportManaCost(float percentageDecrease) {
        teleportAbility.SetManaCost(teleportAbility.GetManaCost() - (teleportAbility.GetManaCost() * percentageDecrease));
    }
    public void ReducePierceShotManaCost(float percentageDecrease) {
        piercingShot.SetManaCost(piercingShot.GetManaCost() - (piercingShot.GetManaCost() * percentageDecrease));
    }

    public void MultiplyBasicAttackDamage(int damageIncrese)
    {
        basicAttack.SetCurrentProjectileDamage(basicAttack.GetMaxProjectileDamage() * damageIncrese);
    }
    public void MultiplyPierceDamage(int damageIncrese)
    {
        piercingShot.SetPiercingCurrentDamge(piercingShot.GetPiercingCurrentDamge() * damageIncrese);
    }

    public void ResetBasicAttckDamege() {
        basicAttack.NormalProjectileDamage();
    }

    public void ResetPierceDamage() {
        piercingShot.NormalPierceDamage();
    }
}
