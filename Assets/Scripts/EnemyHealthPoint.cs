using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthPoint : HealthPoints
{
    public override void Die()
    {
        Debug.Log("Die");
        Destroy(this.gameObject);
        OnDeath.Invoke();
    }

}
