using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class represents a projectile that can pierce through enemies
public class PiercingProjectile : MonoBehaviour 
{
   
    [SerializeField] private float projectileSpeed = 1000f; // Speed of the projectile
    [SerializeField] private float maxLifeTime = 2f; // Maximum lifetime of the projectile
    [SerializeField] private int maxPiercingAmount = 4; // Maximum number of enemies the projectile can pierce through
    [SerializeField] public int maxDamage = 10; // Damage dealt by the projectile
    [SerializeField] private int currentDamage;

    private int currentPiercingAmount; // Current number of enemies the projectile can still pierce through

    private const String ENEMY_TAG = "Enemy"; // Tag used to identify enemy game objects

    private float timer = 0f; // Timer to track the lifetime of the projectile
    private Rigidbody2D rb2D; // Rigidbody component of the projectile
    private Vector2 moveDirection; // Direction in which the projectile is moving

   
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>(); // Get the Rigidbody component
    }

    
    private void Start()
    {
        currentPiercingAmount = maxPiercingAmount; // Reset the current piercing amount
        currentDamage = maxDamage; //Set current damge to damage dealt
    }

   
    private void FixedUpdate()
    {
        MoveProjectile(); // Move the projectile
        timer += Time.deltaTime; // Increase the timer
        if (timer >= maxLifeTime) // If the projectile has exceeded its maximum lifetime
        {
            DisableProjectile(); // Disable the projectile
            timer = 0; // Reset the timer
        }
    }

    // Method to move the projectile
    public void MoveProjectile()    {
        // Calculate the angle of the move direction
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        // Rotate the projectile to face the move direction
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.LerpAngle(transform.rotation.eulerAngles.z, angle, projectileSpeed * Time.deltaTime));
        // Set the velocity of the Rigidbody
        rb2D.velocity = moveDirection * projectileSpeed * Time.fixedDeltaTime;

    }

    // Method to set the move direction of the projectile
    public void SetMoveDirection(Vector2 movDir)
    {
        moveDirection = movDir; // Set the move direction
    }

   
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(ENEMY_TAG))
        {
           
            HealthPoints potentialEnemyHealth = collider.gameObject.GetComponent<EnemyHealthPoints>();
            if (!potentialEnemyHealth) 
            {
                return; 
            }
          
            potentialEnemyHealth.RemoveHealth(currentDamage);
          
            currentPiercingAmount--;
            if (currentPiercingAmount <= 0) { 
                DisableProjectile(); 
            }
        }
    }

    // Method to disable the projectile
    private void DisableProjectile()
    {
        // Disable the game object
        this.gameObject.SetActive(false);
    }

    // Method called when the game object is enabled
    private void OnEnable()
    {
        // Reset the current piercing amount
        currentPiercingAmount = maxPiercingAmount;
    }
    public int GetProjectileDamage() {
        return maxDamage;
    }
    public void SetMaxProjectileDamage(int amt) {
        maxDamage = amt;
    }

    public void NormalProjectileDamage()
    {
        currentDamage = maxDamage;
    }

    public void SetPiercingProjectileDamage(int setdamage)
    {
        currentDamage = setdamage;
    }

    public int GetCurrentPierceDamage()
    {
        return currentDamage;
    }
}
