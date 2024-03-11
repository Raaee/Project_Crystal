using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float projectileSpeed = 1000f;
    [SerializeField] private float maxLifeTime = 2f;
    [SerializeField] private int projectileDamage = 10;
    [SerializeField] private int maxPiercingAmount = 2;
    private int currentPiercingAmount;

    private const String ENEMY_TAG = "Enemy";
    
    private float timer = 0f;
    private Rigidbody2D rb2D;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        SetMoveDirection(new Vector2(0, 1));
    }

    private void Start()
    {
        currentPiercingAmount = maxPiercingAmount;
    }

    private void FixedUpdate()
    {

        MoveProjectile();
        timer += Time.deltaTime;
        if (timer >= maxLifeTime)
        {
            DisableProjectile();
            timer = 0;
        }

    }
    public void MoveProjectile()
    {

        rb2D.velocity = moveDirection * projectileSpeed * Time.fixedDeltaTime;

        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.LerpAngle(transform.rotation.eulerAngles.z, angle, projectileSpeed * Time.deltaTime));

    }

    public void SetMoveDirection(Vector2 movDir)
    {
        moveDirection = movDir;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(ENEMY_TAG))
        {
            HealthPoints potentialEnemyHealth = collider.gameObject.GetComponent<HealthPoints>();
            if (!potentialEnemyHealth)
            {
                return;
            }
            potentialEnemyHealth.RemoveHealth(projectileDamage);
            currentPiercingAmount--;
            if (currentPiercingAmount <= 0)
            {
                DisableProjectile();
                
            }
            
        }
    }

    private void DisableProjectile()
    {
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        currentPiercingAmount = 2;
    }
}
