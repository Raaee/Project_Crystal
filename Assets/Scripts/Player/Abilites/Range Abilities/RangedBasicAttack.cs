using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangedBasicAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    private Actions actions;
    void Awake()
    {

        actions = GetComponent<Actions>();
        actions.OnBasicAttack.AddListener(StartAttack);
        

    }

    public void SpawnProjectile(Vector2 moveDirection)
    {
        GameObject go = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity);
        go.transform.position = this.transform.position;
        go.transform.rotation = Quaternion.identity;
        Projectile projectile = go.GetComponent<Projectile>();
        projectile.SetMoveDirection(moveDirection);

    }

    public void StartAttack()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 direction = (mousePosition - objectPosition).normalized;
        SpawnProjectile(direction);
    }
}
