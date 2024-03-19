using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPoints : HealthPoints
{
    public override void Die()
    {
        Debug.Log("Player dead");
        OnDead?.Invoke();
    }
}
