using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This class represents the Piercing Shot ability for a player character.
public class PiercingShotAbility : Ability
{
    // Serialized fields for Unity inspector
    [SerializeField] private GameObject rangedAbility1Prefab;
    
  //  [SerializeField] float delayBetweenPresses = 0.25f;

    // Private fields
    private Actions actions;
    private ObjectPooler projPooler;

    void Awake()
    {
        // Get the Actions component from the parent object
        actions = GetComponentInParent<Actions>();

        // If Actions component is not found, log an error and break
        if (actions == null)
        {
            Debug.LogError("Actions not found");
            Debug.Break();
        }

        // Add ShootIfActive method as a listener to OnAbility1 event
        actions.OnAbility1.AddListener(ShootIfActive);
    }

    public override void Start()
    {
        projPooler = ObjPoolerManager.instance.GetPool(rangedAbility1Prefab);
    }

    // Method to spawn a projectile in a given direction
    public void SpawnProjectile(Vector2 moveDirection)
    {
        // Get a pooled object and set its position and direction
        GameObject go = projPooler.GetPooledObject();
        go.transform.position = this.transform.position;
        PiercingProjectile projectile = go.GetComponent<PiercingProjectile>();
        projectile.SetMoveDirection(moveDirection);
        go.SetActive(true);
    }

    // Method to shoot if the ability is active
    public void ShootIfActive()
    {
        if (isOnCoolDown)
            return;

        // If the current mana is greater than or equal to the mana cost, use the ability
        if (GetCurrentMana() >= manaCost)
            StartCoroutine(UseAbility());
    }

    // Overridden method for ability usage
    public override void AbilityUsage()
    {
        // Calculate the direction from the object to the mouse position and spawn a projectile in that direction
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 direction = (mousePosition - objectPosition).normalized;
        SpawnProjectile(direction);
    }

    public int GetMaxDamage() {
        return projPooler.GetObjectToPool().GetComponent<PiercingProjectile>().GetProjectileDamage();
    }
    public void SetMaxDamage(int amt) {
        projPooler.GetObjectToPool().GetComponent<PiercingProjectile>().SetMaxProjectileDamage(amt);
    }

    public void SetPiercingCurrentDamge(int amt)
    {
        projPooler.GetObjectToPool().GetComponent<PiercingProjectile>().SetPiercingProjectileDamage(amt);
    }

    public int GetPiercingCurrentDamge()
    {
        return projPooler.GetObjectToPool().GetComponent<PiercingProjectile>().GetCurrentPierceDamage();
    }

    public void NormalPiercesDamage()
    {
        projPooler.GetObjectToPool().GetComponent<PiercingProjectile>().NormalProjectileDamage();
    }
}
