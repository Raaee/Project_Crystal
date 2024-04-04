using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthPoints : HealthPoints
{
    public override void Die()
    {
        OnHealthChange.Invoke();
        OnDead?.Invoke();
       
    }

}
