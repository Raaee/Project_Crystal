using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// This class handles the ranged basic attack for a game character
public class RangedBasicAttack : Ability 
{
    private Actions actions;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private bool isPlayerShooting;
    [SerializeField] private float enemyFireRate = 5.0f;
    [SerializeField] private float playerFireRate = 0.1f;

    [HideInInspector] public UnityEvent OnAttack;
    private float lastPlayerAttackTime = 0f;
    private float lastEnemyAttackTime = 0f;
    private bool isOnCooldown = true; 
       
    void Awake() { 
        
        actions = GetComponentInParent<Actions>();
        // Add listener for basic attack event when basic attack button is pressed
        actions?.OnBasicAttack.AddListener(ShootIfActive);
      
   
        cooldown = playerFireRate;
    }
    public override void Start()
    {
        NormalProjectileDamage();
    }

    // Method to spawn a projectile
    public void SpawnProjectile(Vector2 moveDirection)  {
        // Get a pooled object
        GameObject go = Instantiate(projectilePrefab, transform);
        // Set the position and rotation of the projectile
        go.transform.position = this.transform.position;
        go.transform.rotation = Quaternion.identity;
        // Get the Projectile component and set its move direction
        Projectile projectile = go.GetComponent<Projectile>();
        projectile.SetMoveDirection(moveDirection, isPlayerShooting);
        projectile.CurrentDamage = currentDamage;
        projectile.SetLifeTime(maxLifeTime);
        // Activate the projectile
        go.SetActive(true);
    }
    public void ShootIfActive() {
        if (isOnCoolDown)
            return;

        // If the current mana is greater than or equal to the mana cost, use the ability
        if (GetCurrentMana() >= manaCost)
            AbilityUsage();
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
        UseManaPoints();
        lastPlayerAttackTime = Time.time;
        isOnCooldown = false; // Set canPlayerShoot to false
        StartCoroutine(ResetPlayerShoot()); // Start the coroutine to reset canPlayerShoot
    }

    public void AttackTarget(Transform currentTarget) {

        if(Time.time < lastEnemyAttackTime + enemyFireRate) return;
        
        OnAttack.Invoke();
        Vector2 directionToTarget = (currentTarget.position - this.transform.parent.transform.position).normalized;
        SpawnProjectile(directionToTarget);

        lastEnemyAttackTime = Time.time;
    }

    // Coroutine to reset canPlayerShoot after the playerFireRate time
    private IEnumerator ResetPlayerShoot()  {
        yield return new WaitForSeconds(playerFireRate);
        isOnCooldown = true;
    }
    public float GetPlayerFireRate() {
        return playerFireRate;
    }
    public GameObject GetBasicAttackPrefab() {
        return projectilePrefab;
    }
    public void SetPlayerFireRate(float rate) {
        playerFireRate = rate;
    }
    
    
    // Getters / Setters
    public int GetMaxProjectileDamage() {
        return maxDamage;
    }

    public void SetMaxProjectileDamage(int amt) {
        maxDamage = amt;
    }

    public void NormalProjectileDamage() {
        currentDamage = maxDamage;
    }

    public void SetCurrentProjectileDamage(int setdamage) {
        currentDamage = setdamage;
    }

    public int GetCurrentProjectileDamage() {
        return currentDamage;
    }
}
