using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPoints : MonoBehaviour
{
    // Max mana is set at 50
    [SerializeField] public int maxMP = 100;
    [SerializeField] public int currentMP;

    // Character starts with maximum mana value
    private void Start()
    {
        currentMP = maxMP;
    }

    // Add a certain amount of mana while character's current mana is between 0 and max
    public void AddMana(int regenerateAmount)
    {
        currentMP += regenerateAmount;
        if (currentMP >= maxMP) {
            currentMP = maxMP;
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
        currentMP = maxMP;
    }
    public int GetCurrentMP()
    {
        return currentMP;
    }
    public int GetMaxMP() {
        return maxMP;
    }
}
