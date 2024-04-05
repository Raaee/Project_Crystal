using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class represents a projectile that can pierce through enemies
public class PiercingProjectile : MonoBehaviour 
{
   
    [SerializeField] private float projectileSpeed = 1000f; // Speed of the projectile
    [SerializeField] private float maxLifeTime = 2f; // Maximum lifetime of the projectile
    [SerializeField] public int damage = 10; // Damage dealt by the projectile
    [SerializeField] private int maxPiercingAmount = 4; // Maximum number of enemies the projectile can pierce through
    private int currentPiercingProjectileDamage;

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
        currentPiercingProjectileDamage = damage; //Set current damge to damage dealt
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

    // Method called when the projectile enters a trigger collider
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(ENEMY_TAG)) // If the collider is an enemy
        {
            // Get the HealthPoints component of the enemy
            HealthPoints potentialEnemyHealth = collider.gameObject.GetComponent<HealthPoints>();
            if (!potentialEnemyHealth) // If the enemy does not have a HealthPoints component
            {
                return; // Exit the method
            }
            // Damage the enemy
            potentialEnemyHealth.RemoveHealth(damage);
            // Decrease the current piercing amount
            currentPiercingAmount--;
            if (currentPiercingAmount <= 0) // If the projectile can no longer pierce through enemies
            {
                DisableProjectile(); // Disable the projectile
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
        return damage;
    }
    public void SetMaxProjectileDamage(int amt) {
        damage = amt;
    }

    public void NormalProjectileDamage()
    {
        currentPiercingProjectileDamage = damage;
    }

    public void SetPiercingProjectileDamage(int setdamage)
    {
        currentPiercingProjectileDamage = setdamage;
    }

    public int GetPiercingCurrentProjectileDamage()
    {
        return currentPiercingProjectileDamage;
    }
}
