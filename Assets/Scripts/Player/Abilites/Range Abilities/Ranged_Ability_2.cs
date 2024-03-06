using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Ability_2 : Ability
{
    void Start()
    {
        actions.OnAbility2.AddListener(EnableAbilityIndicator);
        actions.OnBasicAttack.AddListener(DisableAbilityIndicator);
    }

    void Update()
    {

    }
}
