using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 1000f; 
    [SerializeField] private float maxLifeTime = 2f;
    private float timer = 0f;
    private Rigidbody2D rigidbody;
    private Vector2 moveDirection;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        MoveProjectile();
        timer += Time.deltaTime;
        if (timer >= maxLifeTime)
        {
            this.gameObject.SetActive(false);
            timer = 0;
        }
        
    }
    public void MoveProjectile()
    {
        rigidbody.velocity = moveDirection * projectileSpeed * Time.fixedDeltaTime;
    }

    public void SetMoveDirection(Vector2 movDir)
    {
        moveDirection = movDir;
    }
}
