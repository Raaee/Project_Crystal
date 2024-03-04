using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Ability_1 : Ability
{
    void Start()
    {
        actions.OnAbility1.AddListener(EnableAbilityIndicator);
        actions.OnBasicAttack.AddListener(DisableAbilityIndicator);
    }

    private void FixUpdate()
    {
    }
}
