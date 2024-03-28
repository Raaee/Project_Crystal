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
        Debug.Log("Enter Water");
        if (x.gameObject.tag == "Water")
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
                Debug.Log("Take 1 point of damage");
                RemoveHealth(1);
        }
    }
}
