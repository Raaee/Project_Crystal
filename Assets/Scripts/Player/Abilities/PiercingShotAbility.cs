using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This class represents the Piercing Shot ability for a player character.
public class PiercingShotAbility : Ability
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int maxPiercingAmount = 1;
    private Actions actions;

    void Awake()
    {
        actions = GetComponentInParent<Actions>();
        actions.OnAbility1.AddListener(ShootIfActive);
    }
    public override void Start() {
        NormalPierceDamage();
    }

    public void SpawnProjectile(Vector2 moveDirection)
    {
        GameObject go = Instantiate(projectilePrefab, transform);
        go.transform.position = this.transform.position;
        PiercingProjectile projectile = go.GetComponent<PiercingProjectile>();
        projectile.SetMoveDirection(moveDirection);
        projectile.CurrentDamage = currentDamage;
        projectile.SetLifeTime(maxLifeTime);
        projectile.SetPierceAmount(maxPiercingAmount);
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
        return maxDamage;
    }
    public void SetMaxDamage(int amt) {
        maxDamage = amt;
    }

    public GameObject GetPiercesAttackPrefab()
    {
        return projectilePrefab;
    }

    public void SetPiercingCurrentDamge(int amt)
    {
        currentDamage = amt;
    }

    public int GetPiercingCurrentDamge()
    {
        return currentDamage;
    }

    public void NormalPierceDamage()
    {
        currentDamage = maxDamage;
    }
}
