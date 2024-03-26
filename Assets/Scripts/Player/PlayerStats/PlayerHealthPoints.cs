using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPoints : HealthPoints
{
    InputControls input;
    private float countdown = 100;
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

    public void OnTriggerEnter2D(Collider2D x)
    {
        
        if (x.gameObject.tag == "Water")
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
                RemoveHealth(1);
        }
    }
}
