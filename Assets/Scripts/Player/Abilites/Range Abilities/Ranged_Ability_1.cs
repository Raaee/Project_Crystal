using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Ability_1: Ability
{
    [SerializeField] private GameObject AbilityIndicator;

    void Start()
    {
        IsActive = true;
        
    }

    private void Update()
    {
        IfAbilityIncatorIsActive();
    }

    //Use IsActive To do something with the EnableAbilityIndicator
    //If the others abilty indicator is active the others cannot be active
    //why did he ask to use EnableAbilityIndicator

    public void IfAbilityIncatorIsActive()
    {
        if (IsActive)
        {
            Debug.Log(IsActive);
            actions.OnAbility1.AddListener(EnableAbilityIndicator);
            actions.OnBasicAttack.AddListener(DisableAbilityIndicator);
        }
    }
}
