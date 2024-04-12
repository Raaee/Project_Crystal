using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// This is an abstract class for player abilities
public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected int maxDamage = 10; // The damage normal/max dealt by the projectile
    [SerializeField] protected int currentDamage = 10; // current damage the projectile does
    [SerializeField] protected float maxLifeTime = 2f; // Maximum lifetime of the projectile
    // Cooldown time for the ability
    [SerializeField] public float cooldown;
    // Mana cost of the ability
    [SerializeField] protected float manaCost;
    // Flag to check if the ability is active
    [SerializeField] protected bool IsActive;
    // Reference to the player's mana points
   [SerializeField] protected ManaPoints userMana;
    // Flag to check if the ability is on cooldown
    protected bool isOnCoolDown = false;
    [HideInInspector] public UnityEvent OnAbilityUsage;

   public virtual void Start() {
        userMana = GetComponentInParent<ManaPoints>();
    }

    // Coroutine to use the ability and put it on cooldown
    public IEnumerator UseAbility()
    {
        // Set the ability to be on cooldown
        isOnCoolDown = true;
        // Call the abstract method for ability usage
        AbilityUsage();
        // Use the required mana points for the ability
        UseManaPoints();
        OnAbilityUsage.Invoke();
        // Wait for the cooldown period
        yield return new WaitForSeconds(cooldown);
        // Set the ability to be off cooldown
        isOnCoolDown = false;
    }

    // Method to use mana points
    public void UseManaPoints()
    {
        // Remove the mana cost of the ability from the player's mana points
        userMana.RemoveMana(manaCost);
    }
    // Abstract method for ability usage to be implemented by child classes
    public abstract void AbilityUsage();

    // Method to get the current mana points of the player
    public float GetCurrentMana() => userMana.GetCurrentMP();
    public void SetManaCost(float cost) {
        manaCost = cost;
        if (manaCost < 0.1f) {
            manaCost = 0.1f;
        }
    }
    public float GetManaCost() => manaCost;
    // Method to get cooldownTime
    public float GetCooldownTime() 
    {
        return cooldown;
    }

    // Method to get cooldown state
    public bool GetIsOnCooldown()
    {
        return isOnCoolDown;
    }
    public void SetCooldown(float cd) {
        cooldown = cd;
    }
}
