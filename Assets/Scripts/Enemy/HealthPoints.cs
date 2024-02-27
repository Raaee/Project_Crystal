using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    // Max health is set at 100
    [SerializeField] private int MAX_HP = 100;
    [SerializeField] private int currentHP;

    // Character starts with maximum health value
    private void Start()
    {
        currentHP = MAX_HP;
    }

    // Add a certain amount of health while character's current health is between 0 and max
    public void AddHealth(int healAmount)
    {
        if (currentHP < MAX_HP && currentHP > 0)
        {
            if ((currentHP + healAmount) > MAX_HP)
            {
                healAmount = MAX_HP - currentHP;
            }
            currentHP += healAmount;
        }
    }

    // Remove a certain amount of health while character's current health is above 0
    public void RemoveHealth(int damageAmount)
    {
        if (currentHP > 0)
        {
            if (currentHP < damageAmount)
            {
                damageAmount = currentHP;
            }
            currentHP -= damageAmount;
        }
    }

    // Returns true if character's health is 0
    public bool IsDead()
    {
        return (currentHP == 0);
    }
}
