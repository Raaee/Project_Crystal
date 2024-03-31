using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPoints : HealthPoints
{
    InputControls input;
    [SerializeField]private bool IsDrowning = false;
    [SerializeField] private float drowningTimer = 0f;
    [SerializeField] public float drowningInterval = 2f;

    public override void Start() {
        base.Start();
        input = GetComponent<InputControls>();
      
    }

    private void Update()
    {
        PlayerDrowning(IsDrowning);
    }
    public override void Die()
    {
        Debug.Log("Player dead");
        OnDead?.Invoke();
    }
    public override void ResetHealth() {
        base.ResetHealth();
    }

    public void PlayerDrowning(bool Drowning) {
        drowningTimer += Time.deltaTime;
        if (Drowning && drowningTimer >= drowningInterval)
        {
            RemoveHealth(1);
            drowningTimer = 0f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Water") { 
            IsDrowning = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Water"){
            IsDrowning = false;
        }
    }
}
