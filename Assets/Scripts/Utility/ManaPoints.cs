using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPoints : MonoBehaviour
{
    // Max mana is set at 50
    [SerializeField] private int MAX_MP = 100;
    [SerializeField] private int currentMP;

    // Character starts with maximum mana value
    private void Start()
    {
        currentMP = MAX_MP;
    }

    // Add a certain amount of mana while character's current mana is between 0 and max
    public void AddMana(int regenerateAmount)
    {
        currentMP += regenerateAmount;
        if (currentMP >= MAX_MP) {
            currentMP = MAX_MP;
        }
    }

    // Remove a certain amount of mana while character's current mana is above 0
    public void RemoveMana(int loseAmount)
    {
        currentMP -= loseAmount;
        if(currentMP <= 0)
        {
            currentMP = 0;
            
        }
    }
    public void ResetMana() {
        currentMP = MAX_MP;
    }
    public int GetCurrentMP()
    {
        return currentMP;
    }
}
