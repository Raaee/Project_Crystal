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
    [SerializeField] public int currentHP;
    [SerializeField] private bool godMode;
    
    private bool isDead = false;
    [HideInInspector] public UnityEvent OnDead;
    [HideInInspector] public UnityEvent OnHurt;

    // Character starts with maximum health value
    public virtual void Start()    {
        ResetHealth();       
    }

    // Add a certain amount of health while character's current health is between 0 and max
    public void AddHealth(int healAmount)   {
        currentHP += healAmount;
        if (currentHP >= maxHP)    {
            currentHP = maxHP;
        }
    }

    // Remove a certain amount of health while character's current health is above 0
    public void RemoveHealth(int damageAmount)  {
        if (godMode)
        {
            return;
        }

        currentHP -= damageAmount;
        
        // Dying is here:
        if (currentHP <= 0) {
            currentHP = 0;
            if (IsDead() == false)
            {
                isDead = true;
                Die();
            }
            return;
        }
        OnHurt.Invoke();
    }

    // Returns true if character's health is 0
    public bool IsDead()    {
        return isDead;
    }

    public virtual void Die()   {
        
    } 
    [ProButton]
    public virtual void ResetHealth()   {
        currentHP = maxHP;
        isDead = false;
    }
}
