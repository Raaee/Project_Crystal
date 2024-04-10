using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using UnityEngine.Events;

public class HealthPoints : MonoBehaviour
{
    // Max health is set at 100
    [SerializeField] public int maxHP = 100;
    [field: SerializeField] public int currentHP { get; set; }
    [SerializeField] private bool godMode;
    
    private bool isDead = false;
    [HideInInspector] public UnityEvent OnDead;
    [HideInInspector] public UnityEvent OnHurt;
    [HideInInspector] public UnityEvent OnHealthChange;

    // Character starts with maximum health value
    public virtual void Start()    {
        ResetHealth();       
    }

    // Add a certain amount of health while character's current health is between 0 and max
    public void AddHealth(int healAmount)   {
        currentHealth += healAmount;
        if (currentHealth >= maxHP)    {
            currentHealth = maxHP;
        }
        OnHealthChange.Invoke();
    }

    // Remove a certain amount of health while character's current health is above 0
    public void RemoveHealth(int damageAmount)  {
        if (godMode)
        {
            return;
        }

        currentHealth -= damageAmount;
        
        // Dying is here:
        if (currentHealth <= 0) {
            currentHealth = 0;
            if (IsDead() == false)
            {
                isDead = true;
                Die();
            }
            return;
        }
        OnHurt.Invoke();
        OnHealthChange.Invoke();
    }

    // Returns true if character's health is 0
    public bool IsDead()    {
        return isDead;
    }
    public virtual void Die() {} 
    [ProButton]
    public virtual void ResetHealth()   {
        currentHealth = maxHP;
        isDead = false;
        OnHealthChange.Invoke();
    }

    // Method To Get Current HP
    public int GetCurrentHP()
    {
        return currentHealth;
    }
    public void SetMaxHealth(int amt) {
        maxHP = amt;
        OnHealthChange.Invoke();
    }
    public int GetMaxHealth() {
        return maxHP;
    }
    public void ToggleGooseMode()
    {
        godMode = !godMode;
    }
}
