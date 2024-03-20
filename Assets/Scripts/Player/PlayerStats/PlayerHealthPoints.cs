using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPoints : HealthPoints
{
    InputControls input;
    private void Start() {
        input = GetComponentInParent<InputControls>();
        
    }
    public override void Die()
    {
        Debug.Log("Player dead");
        OnDead?.Invoke();
    }
    public override void Respawn() {
        base.Respawn();
        input.OnEnable();
    }
}
