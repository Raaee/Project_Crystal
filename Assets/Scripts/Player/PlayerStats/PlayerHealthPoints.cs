using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPoints : HealthPoints
{
    InputControls input;
    public override void Start() {
        base.Start();
        input = GetComponent<InputControls>();
    }
    public override void Die()
    {
        Debug.Log("Player dead");
        OnDead?.Invoke();
        input.OnDisable();
        Destroy(this.gameObject);
    }
    public override void ResetHealth() {
        base.ResetHealth();
        //input.OnEnable();
    }
}
