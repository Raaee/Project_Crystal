using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : AbilityIndicator
{
    [SerializeField] protected int cooldown;
    [SerializeField] protected int manaCost;

    //Solve this problem
    ///protected Actions actions;
}
