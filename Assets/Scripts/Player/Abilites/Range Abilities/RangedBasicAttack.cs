using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This class handles the ranged basic attack for a game character
public class RangedBasicAttack : MonoBehaviour
{
    // Prefab for the basic attack
    [SerializeField] private GameObject angedBasicAttackPrefab;
    // Object pooler for projectiles
    [SerializeField] private ObjectPooler projPooler;
    // Actions component
    private Actions actions;

   
    void Awake()
    {
        // Get the Actions component from the parent object
        actions = GetComponentInParent<Actions>();
        // Add StartAttack as a listener to the OnBasicAttack event
        actions.OnBasicAttack.AddListener(StartAttack);
    }

    // Method to spawn a projectile
    public void SpawnProjectile(Vector2 moveDirection)
    {
        // Get a pooled object
        GameObject go = projPooler.GetPooledObject();
        // Set the position and rotation of the projectile
        go.transform.position = this.transform.position;
        go.transform.rotation = Quaternion.identity;
        // Get the Projectile component and set its move direction
        Projectile projectile = go.GetComponent<Projectile>();
        projectile.SetMoveDirection(moveDirection);
        // Activate the projectile
        go.SetActive(true);
    }

    // Method to start the attack
    public void StartAttack()
    {
        // Get the mouse position and the object position
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        // Calculate the direction of the attack
        Vector2 direction = (mousePosition - objectPosition).normalized;
        // Spawn the projectile
        SpawnProjectile(direction);
    }
}
