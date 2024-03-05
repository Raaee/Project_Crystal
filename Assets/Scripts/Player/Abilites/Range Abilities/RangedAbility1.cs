using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangedAbility1 : Ability
{
    [SerializeField] private GameObject rangedAbility1Prefab;
    [SerializeField] private ObjectPooler projPooler;
    private Actions actions;
    void Awake()
    {

        actions = GetComponent<Actions>();
        actions.OnAbility1.AddListener(Shoot);

    }
    public void SpawnProjectile(Vector2 moveDirection)
    {
        GameObject go = projPooler.GetPooledObject();
        go.transform.position = this.transform.position;
        go.transform.rotation = Quaternion.identity;
        /*go.transform.eulerAngles += new Vector3(0, 0, 180);*/
        Projectile projectile = go.GetComponent<Projectile>();
        projectile.SetMoveDirection(moveDirection);
        go.SetActive(true);

    }
    public void Shoot()
    {
        if (isOnCoolDown)
            return;
       

        StartCoroutine(UseAbility());

    }
    public override void AbilityUsage()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 direction = (mousePosition - objectPosition).normalized;
        SpawnProjectile(direction);

    }
}
