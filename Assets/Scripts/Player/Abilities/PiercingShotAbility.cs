using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This class represents the Piercing Shot ability for a player character.
public class PiercingShotAbility : Ability
{
    [SerializeField] private GameObject projectilePrefab;
    
    private Actions actions;
    private ObjectPooler projPooler;

    void Awake()
    {
        actions = GetComponentInParent<Actions>();
        actions.OnAbility1.AddListener(ShootIfActive);
    }

    public void SpawnProjectile(Vector2 moveDirection)
    {
        GameObject go = Instantiate(projectilePrefab, transform);
        go.transform.position = this.transform.position;
        PiercingProjectile projectile = go.GetComponent<PiercingProjectile>();
        projectile.SetMoveDirection(moveDirection);
        go.SetActive(true);
    }

    public void ShootIfActive()
    {
        if (isOnCoolDown)
            return;

        // If the current mana is greater than or equal to the mana cost, use the ability
        if (GetCurrentMana() >= manaCost)
            StartCoroutine(UseAbility());
    }

    public override void AbilityUsage()
    {
        // Calculate the direction from the object to the mouse position and spawn a projectile in that direction
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 direction = (mousePosition - objectPosition).normalized;
        SpawnProjectile(direction);
    }

    public int GetMaxDamage() {
        return projectilePrefab.GetComponent<PiercingProjectile>().GetProjectileDamage();
    }
    public void SetMaxDamage(int amt) {
        projectilePrefab.GetComponent<PiercingProjectile>().SetMaxProjectileDamage(amt);
    }

    public void SetPiercingCurrentDamge(int amt)
    {
        projectilePrefab.GetComponent<PiercingProjectile>().SetCurrentPierceDamage(amt);
    }

    public int GetPiercingCurrentDamge()
    {
        return projectilePrefab.GetComponent<PiercingProjectile>().GetCurrentPierceDamage();
    }

    public void NormalPierceDamage()
    {
        projectilePrefab.GetComponent<PiercingProjectile>().NormalProjectileDamage();
    }
}
