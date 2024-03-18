using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthPoint : HealthPoints
{
    public override void Die(){
        Destroy(this.gameObject);
    }
   
}
