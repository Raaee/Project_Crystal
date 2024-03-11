using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected int cooldown;
    [SerializeField] protected int manaCost;
    [SerializeField] protected bool IsActive;
    [SerializeField] protected ManaPoints playerMana;
    protected bool isOnCoolDown = false;

    private void Awake()
    {
        playerMana = GetComponentInParent<ManaPoints>();
    }

    public IEnumerator UseAbility() //Make this in abstract ability class minus transformed.position
    {
        isOnCoolDown = true;
        AbilityUsage();
        UseManaPoints();
        yield return new WaitForSeconds(cooldown);
        isOnCoolDown = false;
        
    }

    public void UseManaPoints()
    {
        playerMana.RemoveMana(manaCost);
    }
    public abstract void AbilityUsage();
    //protected Actions actions;

    public int GetCurrentMana() => playerMana.GetCurrentMP();


}
