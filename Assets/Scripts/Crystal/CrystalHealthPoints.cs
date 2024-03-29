using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CrystalHealthPoints : HealthPoints
{
    public override void Die()
    {
        Debug.Log("Crystal dead");
        OnDead?.Invoke();
    }
}
