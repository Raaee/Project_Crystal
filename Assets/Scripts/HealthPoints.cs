using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using UnityEngine.Events;

public class HealthPoints : MonoBehaviour
{
    // Max health is set at 100
    [SerializeField] private int MAX_HP = 100;
    [SerializeField] private int currentHP;
    InputControls input;
    private bool isDead = false;
    public UnityEvent OnDead;

    // Character starts with maximum health value
    private void Start()
    {
        currentHP = 30;
        input = GetComponentInParent<InputControls>();
    }

    // Add a certain amount of health while character's current health is between 0 and max
    public void AddHealth(int healAmount)
    {
        if (currentHP < MAX_HP && currentHP > 0)
        {
            if ((currentHP + healAmount) > MAX_HP)
            {
                healAmount = MAX_HP - currentHP;
            }
            currentHP += healAmount;
        }
    }

    // Remove a certain amount of health while character's current health is above 0
    public void RemoveHealth(int damageAmount)
    {
        currentHP -= damageAmount;
        if (currentHP <= 0)
        {
            currentHP = 0;
            if (IsDead() == false)
            {
                isDead = true;
                Die();
               
            }
        }
    }

    // Returns true if character's health is 0
    public bool IsDead()
    {
        return isDead;
    }

    public virtual void Die()
    {
        
    }
 

    // Enemy gets destroyed by projectile
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
    [ProButton]
    public void Respawn()
    {
      
        currentHP = MAX_HP;
        isDead = false;
        input.OnEnable();
    }
}
