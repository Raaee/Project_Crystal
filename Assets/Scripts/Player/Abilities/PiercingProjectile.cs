using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class represents a projectile that can pierce through enemies
public class PiercingProjectile : MonoBehaviour 
{
   
    [SerializeField] private float projectileSpeed = 1000f; // Speed of the projectile
    private float lifeTime = 2f; // Maximum lifetime of the projectile
    private int maxPiercingAmount = 2; // Maximum number of enemies the projectile can pierce through
    public int CurrentDamage { get; set; } // current damage the projectile does

    private int currentPiercingAmount; // Current number of enemies the projectile can still pierce through

    private const string ENEMY_TAG = "Enemy"; // Tag used to identify enemy game objects

    private float timer = 0f; // Timer to track the lifetime of the projectile
    private Rigidbody2D rb2D; // Rigidbody component of the projectile
    private Vector2 moveDirection; // Direction in which the projectile is moving

   
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>(); // Get the Rigidbody component
    }

    private void FixedUpdate()
    {
        MoveProjectile(); // Move the projectile
        timer += Time.deltaTime; // Increase the timer
        if (timer >= lifeTime) // If the projectile has exceeded its maximum lifetime
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
            potentialEnemyHealth.RemoveHealth(CurrentDamage);
          
            currentPiercingAmount--;
            if (currentPiercingAmount <= 0) { 
                DisableProjectile(); 
            }
        }
    }

    // Disables the projectile.
    private void DisableProjectile() {
        Destroy(this.gameObject);
    }

    // Method called when the game object is enabled
    private void OnEnable()
    {
        // Reset the current piercing amount
        currentPiercingAmount = maxPiercingAmount;
    }
    public void SetLifeTime(float life) {
        lifeTime = life;
    }
    public void SetPierceAmount(int amt) {
        maxPiercingAmount = amt;
    }
}
