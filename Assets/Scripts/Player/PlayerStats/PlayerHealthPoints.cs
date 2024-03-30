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
    }
    public override void ResetHealth() {
        base.ResetHealth();
    }

    public void OnTriggerEnter2D(Collider2D x) {
        if (x.gameObject.tag == "Water") { 
            Debug.Log("Remove Health");
        }
    }
}
