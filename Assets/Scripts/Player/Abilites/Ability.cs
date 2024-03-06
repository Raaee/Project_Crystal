using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : AbilityIndicator
{
    [SerializeField] protected int cooldown;
    [SerializeField] protected int manaCost;
    [SerializeField] protected bool IsActive;
    protected bool isOnCoolDown = false;



    public IEnumerator UseAbility() //Make this in abstract ability class minus transformed.position
    {
        isOnCoolDown = true;
        AbilityUsage();
        yield return new WaitForSeconds(cooldown);
        isOnCoolDown = false;
        
    }
    public abstract void AbilityUsage();
    //protected Actions actions;
    
}
