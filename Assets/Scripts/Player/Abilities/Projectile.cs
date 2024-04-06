using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

// The Projectile class handles the behavior of projectiles in the game.
public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 1000f; // The speed of the projectile.
    [SerializeField] private float maxLifeTime = 2f; // The maximum lifetime of the projectile.
    private const String ENEMY_TAG = "Enemy"; // Tag used to identify enemies.
    private const String PLAYER_TAG = "Player"; // Tag used to identify the player.
    private const String CRYSTAL_TAG = "Crystal"; // Tag used to identify the crystal.
    [SerializeField] public int damage = 10; // The damage dealt by the projectile.
    private int currentProjectileDamage;
    private float timer = 0f; // Timer used to track the lifetime of the projectile.
    private Rigidbody2D rb2D; // The Rigidbody2D component of the projectile.
    private Vector2 moveDirection; // The direction in which the projectile is moving.
    private bool isPlayerShooting = true;

    private void Awake()
    {
        // Get the Rigidbody2D component attached to the game object this script is attached to.
        rb2D = GetComponent<Rigidbody2D>();

        // Set the initial direction of the projectile to upwards.
    }
    private void Start()
    {
        currentProjectileDamage = damage;
    }

    // FixedUpdate is called every fixed framerate frame.
    private void FixedUpdate()
    {
        // Move the projectile
        MoveProjectile();

        // Increment the timer by the time passed since the last frame
        timer += Time.deltaTime;

        // If the projectile has existed for longer than its maximum lifetime
        if (timer >= maxLifeTime)
        {
            // Disable the projectile
            DisableProjectile();

            // Reset the timer
            timer = 0;
        }
    }

    // Moves the projectile in its current direction.
    public void MoveProjectile() {
        // Calculate the angle of the projectile's direction in degrees.
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        // Set the rotation of the projectile to face the direction it's moving, smoothly transitioning over time.
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.LerpAngle(transform.rotation.eulerAngles.z, angle, projectileSpeed * Time.deltaTime));
        // Set the velocity of the projectile by multiplying the direction, speed, and time since the last frame.
        rb2D.velocity = moveDirection * projectileSpeed * Time.fixedDeltaTime;
    }

    // Sets the direction in which the projectile should move.
    public void SetMoveDirection(Vector2 movDir, bool isPlayerShooting)
    {
        this.isPlayerShooting = isPlayerShooting;
        moveDirection = movDir;
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only).
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the projectile has collided with an enemy
        if (collider.gameObject.CompareTag(ENEMY_TAG))
        {
            if (isPlayerShooting) {
                // Get the HealthPoints component of the enemy
                HealthPoints potentialEnemyHealth = collider.gameObject.GetComponent<HealthPoints>();
                // If the enemy does not have a HealthPoints component, exit the function
                if (!potentialEnemyHealth) {
                    return;
                }
                // Reduce the health of the enemy by the damage of the projectile
                potentialEnemyHealth.RemoveHealth(damage);
                // Disable the projectile after it has hit an enemy
                DisableProjectile();
            }
        }
        // Check if the projectile has collided with the player
        else if (collider.gameObject.CompareTag(PLAYER_TAG))
        {
            if (isPlayerShooting)
            {
                return;
            }
            // Get the HealthPoints component of the player
            HealthPoints potentialPlayerHealth = collider.gameObject.GetComponent<HealthPoints>();
            // If the player does not have a HealthPoints component, exit the function
            if (!potentialPlayerHealth)
            {
                return;
            }
            // Reduce the health of the player by the damage of the projectile
            potentialPlayerHealth.RemoveHealth(damage);
            // Disable the projectile after it has hit the player
            DisableProjectile();
        }
        // Check if the projectile has collided with the crystal
        else if (collider.gameObject.CompareTag(CRYSTAL_TAG))
        {
            if (isPlayerShooting)
            {
                return;
            }
            // Get the HealthPoints component of the crystal
            HealthPoints potentialCrystalHealth = collider.gameObject.GetComponent<HealthPoints>();
            // If the crystal does not have a HealthPoints component, exit the function
            if (!potentialCrystalHealth)
            {
                return;
            }
            // Reduce the health of the crystal by the damage of the projectile
            potentialCrystalHealth.RemoveHealth(damage);
            // Disable the projectile after it has hit the player
            DisableProjectile();
        }
        // If the projectile has collided with something other than an enemy or the player, disable the projectile
    }

    // Disables the projectile.
    private void DisableProjectile()
    {
        this.gameObject.SetActive(false);
    }

    public int GetProjectileDamage() {
        return damage;
    }

    public void SetMaxProjectileDamage(int amt) {
        damage = amt;
    }

    public void NormalProjectileDamage()
    {
        currentProjectileDamage = damage;
    }

    public void SetProjectileDamage(int setdamage)
    {
        currentProjectileDamage = setdamage;
    }

    public int GetCurrentProjectileDamage()
    {
        return currentProjectileDamage;
    }
}
