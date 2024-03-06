using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : AbilityIndicator
{
    [SerializeField] protected int cooldown;
    [SerializeField] protected int manaCost;
    //protected Actions actions;
    [SerializeField] protected bool IsActive;
}
