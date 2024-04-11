using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private int intitialDamage = 10;
    [SerializeField] private int maxDamage = 10; // The damage normal/max dealt by the projectile
    [SerializeField] private int currentDamage = 10; // current damage the projectile does
    //[SerializeField] public int EnemyProjectileDamage = 10;

    private void Start()
    {
        maxDamage = intitialDamage;
        currentDamage = maxDamage;
    }

    public int GetInitialDamage()
    {
        return intitialDamage;
    }

    public void SetInitialDamage(int amt)
    {
        intitialDamage = amt;
    }

    public int GetDamage()
    {
        return maxDamage;
    }

    public void SetMaxDamage(int amt)
    {
        maxDamage = amt;
        NormalDamage();
    }

    public int GetCurrentDamage() {
        return currentDamage;
    }

    public void SetCurrentDamage(int amt)
    {
        currentDamage = amt;
    }

    public void NormalDamage()
    {
        intitialDamage = maxDamage;
    }
}
