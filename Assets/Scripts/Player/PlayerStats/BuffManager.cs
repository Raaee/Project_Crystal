using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class BuffManager : MonoBehaviour  {

    [SerializeField] private GameObject playerPrefab;
    // Player Stats
    private PlayerHealthPoints playerHealth;
    private ManaPoints playerMana;
    private PlayerMovement playerMovement;

    // Abilities
    private TeleportAbility teleportAbility;
    private RangedBasicAttack basicAttack;
    private PiercingShotAbility piercingShot;

    void Awake() {
        playerHealth = playerPrefab.GetComponent<PlayerHealthPoints>();
        playerMana = playerPrefab.GetComponent<ManaPoints>();
        playerMovement = playerPrefab.GetComponent<PlayerMovement>();
        teleportAbility = playerPrefab.GetComponentInChildren<TeleportAbility>();
        basicAttack = playerPrefab.GetComponentInChildren<RangedBasicAttack>();
        piercingShot = playerPrefab.GetComponentInChildren<PiercingShotAbility>();
    }
    // Health
    public void AddHealth(int amt) {
        playerHealth.AddHealth(amt);
    }
    public void RemoveHealth(int amt) {
        playerHealth.RemoveHealth(amt);
    }
    public void IncreaseMaxHealth(float percentageIncrease) {
        int maxHP = playerHealth.GetMaxHealth();
        playerHealth.SetMaxHealth(maxHP + (int)(maxHP * percentageIncrease));
    }
    public int GetCurrentHealth() {
        return playerHealth.GetCurrentHP();
    }
    // Mana
    public void AddMana(int amt) {
        playerMana.AddMana(amt);
    }
    public void RemoveMana(int amt) {
        playerMana.RemoveMana(amt);
    }
    public void IncreaseMaxMana(float percentageIncrease) {
        int maxMP = playerMana.GetMaxMana();
        playerMana.SetMaxMana(maxMP + (int)(maxMP * percentageIncrease));
    }    
    public int GetCurrentMana() {
        return playerMana.GetCurrentMP();
    }
    // Basic Attack
    public void IncreaseMaxBasicAttackDamage(float percentageIncrease) {
        int damage = basicAttack.GetMaxDamage();
        basicAttack.SetMaxDamage(damage + (int)(damage * percentageIncrease));
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

}
