using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPoints : MonoBehaviour
{
    // Max mana is set at 50
    [SerializeField] private int MAX_MP = 50;
    [SerializeField] private int currentMP;

    // Character starts with maximum mana value
    private void Start()
    {
        currentMP = MAX_MP;
    }

    // Add a certain amount of mana while character's current mana is between 0 and max
    public void AddMana(int regenerateAmount)
    {
        if (currentMP < MAX_MP && currentMP > 0)
        {
            if ((currentMP + regenerateAmount) > MAX_MP)
            {
                regenerateAmount = MAX_MP - currentMP;
            }
            currentMP += regenerateAmount;
        }
    }

    // Remove a certain amount of mana while character's current mana is above 0
    public void RemoveMana(int loseAmount)
    {
        if (currentMP > 0)
        {
            if (currentMP < loseAmount)
            {
                // Probably a message for UI that says you cant use the ability
            } else
            {
                currentMP -= loseAmount;
            }
        }
    }
}
