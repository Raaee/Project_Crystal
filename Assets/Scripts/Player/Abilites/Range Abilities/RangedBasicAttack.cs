using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangedBasicAttack : MonoBehaviour
{
    [SerializeField] private GameObject angedBasicAttackPrefab;
    [SerializeField] private ObjectPooler projPooler;
    private Actions actions;
    void Awake()
    {

        actions = GetComponentInParent<Actions>();
        actions.OnBasicAttack.AddListener(StartAttack);
        

    }

    public void SpawnProjectile(Vector2 moveDirection)
    {
        GameObject go = projPooler.GetPooledObject();
        go.transform.position = this.transform.position;
        go.transform.rotation = Quaternion.identity;
        Projectile projectile = go.GetComponent<Projectile>();
        projectile.SetMoveDirection(moveDirection);
        go.SetActive(true);

    }

    public void StartAttack()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 direction = (mousePosition - objectPosition).normalized;
        SpawnProjectile(direction);
    }

}
