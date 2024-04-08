using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// The Projectile class handles the behavior of projectiles in the game.
public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 1000f; // The speed of the projectile.
    [SerializeField] private float maxLifeTime = 2f; // The maximum lifetime of the projectile.
    private const String ENEMY_TAG = "Enemy"; // Tag used to identify enemies.
    private const String PLAYER_TAG = "Player"; // Tag used to identify the player.
    private const String CRYSTAL_TAG = "Crystal"; // Tag used to identify the crystal.
    [SerializeField] public int maxDamage = 10; // The damage normal/max dealt by the projectile.
    private int currentDamage; // current damage the projectile does
    private float timer = 0f; // Timer used to track the lifetime of the projectile.
    private Rigidbody2D rb2D; // The Rigidbody2D component of the projectile.
    private Vector2 moveDirection; // The direction in which the projectile is moving.
    private bool isPlayerShooting = true;

    [HideInInspector] public UnityEvent OnProjectileDisabled;

    private void Awake()    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        currentDamage = maxDamage;
    }

    private void FixedUpdate()
    {
        MoveProjectile();

        timer += Time.deltaTime;

        // If the projectile has existed for longer than its maximum lifetime, disable it
        if (timer >= maxLifeTime)
        {
            DisableProjectile();
            timer = 0;
        }
    }

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
        if (collider.gameObject.CompareTag(ENEMY_TAG))
        {
            if (isPlayerShooting) {
                EnemyHealthPoints potentialEnemyHealth = collider.gameObject.GetComponent<EnemyHealthPoints>();

                if (!potentialEnemyHealth) {
                    return;
                }
                Debug.Log("BA: " + currentDamage);
                potentialEnemyHealth.RemoveHealth(currentDamage);

                // Disable the projectile after it has hit an enemy
                DisableProjectile();
            }
        }
        // Check if the projectile has collided with the player
        else if (collider.gameObject.CompareTag(PLAYER_TAG))
        {
            if (isPlayerShooting) {
                return;
            }
            
            HealthPoints potentialPlayerHealth = collider.gameObject.GetComponent<HealthPoints>();

            if (!potentialPlayerHealth) {
                return;
            }
            

            potentialPlayerHealth.RemoveHealth(currentDamage);
            DisableProjectile();
        }
        // Check if the projectile has collided with the crystal
        else if (collider.gameObject.CompareTag(CRYSTAL_TAG))
        {
            if (isPlayerShooting) {
                return;
            }
            HealthPoints potentialCrystalHealth = collider.gameObject.GetComponent<HealthPoints>();

            if (!potentialCrystalHealth)    {
                return;
            }
            potentialCrystalHealth.RemoveHealth(currentDamage);
            
            //DisableProjectile(); // Uncomment this to not have piercing on crystal.
        }
    }

    private void DisableProjectile()
    {
        OnProjectileDisabled?.Invoke();
        Destroy(this.gameObject);
    }
   
  
    public int GetProjectileDamage() {
        return maxDamage;
    }

    public void SetMaxProjectileDamage(int amt) {
        maxDamage = amt;
        NormalProjectileDamage();
    }

    public void NormalProjectileDamage()
    {
        currentDamage = maxDamage;
    }

    public void SetProjectileDamage(int setdamage)
    {
        currentDamage = setdamage;
    }

    public int GetCurrentProjectileDamage()
    {
        return currentDamage;
    }
}
