using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This class handles the ranged basic attack for a game character
public class RangedBasicAttack : Ability 
{

    private Actions actions;

    // Object pooler for projectiles
    [SerializeField] public ObjectPooler projPooler;
    [SerializeField] private bool isPlayerShooting;
    [SerializeField] private float enemyFireRate = 5.0f;
    [SerializeField] private float playerFireRate = 0.1f;

    private float lastPlayerAttackTime = 0f;
    private float lastEnemyAttackTime = 0f;
    private bool isOnCooldown = true; 
       
    void Awake() { 
        
        actions = GetComponentInParent<Actions>();
        // Add listener for basic attack event when basic attack button is pressed
        actions?.OnBasicAttack.AddListener(AbilityUsage);

        cooldown = playerFireRate;
    }

    // Method to spawn a projectile
    public void SpawnProjectile(Vector2 moveDirection)  {
        // Get a pooled object
        GameObject go = projPooler.GetPooledObject();
        // Set the position and rotation of the projectile
        go.transform.position = this.transform.position;
        go.transform.rotation = Quaternion.identity;
        // Get the Projectile component and set its move direction
        Projectile projectile = go.GetComponent<Projectile>();
        projectile.SetMoveDirection(moveDirection, isPlayerShooting);
        // Activate the projectile
        go.SetActive(true);
    }

    // Method to start the attack
    public override void AbilityUsage() {

        if (!isOnCooldown) return; // Check if the player can shoot
        if (Time.time < lastPlayerAttackTime + playerFireRate) return;

        // Get the mouse position and the object position
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        // Calculate the direction of the attack
        Vector2 direction = (mousePosition - objectPosition).normalized;
        // Spawn the projectile
        SpawnProjectile(direction);

        lastPlayerAttackTime = Time.time;
        isOnCooldown = false; // Set canPlayerShoot to false
        StartCoroutine(ResetPlayerShoot()); // Start the coroutine to reset canPlayerShoot
    }

    public void AttackTarget(Transform currentTarget) {

        if(Time.time < lastEnemyAttackTime + enemyFireRate) return;

        Vector2 directionToTarget = (currentTarget.position - this.transform.parent.transform.position).normalized;
        SpawnProjectile(directionToTarget);

        lastEnemyAttackTime = Time.time;
    }

    // Coroutine to reset canPlayerShoot after the playerFireRate time
    private IEnumerator ResetPlayerShoot()  {
        yield return new WaitForSeconds(playerFireRate);
        isOnCooldown = true;
    }
}
