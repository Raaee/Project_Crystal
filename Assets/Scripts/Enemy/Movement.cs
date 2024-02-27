using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject target1;
    private Transform spawnedBy;
    private bool isAggroed;
    [SerializeField] private float aggroTime = 5f;
    private float aggroTimer = 0f;
    private Transform currTarget;

    public void Start()
    {
        SetInitialTarget();
    }

    void SetInitialTarget()
    {
        if(spawnedBy != null)
        {
            currTarget = spawnedBy;
        }
    }

    public void Update()
    {
        if(currTarget != null)
        {
            MoveTowardsTarget(currTarget);
        }

        if (isAggroed)
        {
            aggroTimer -= Time.deltaTime;
            if (aggroTimer <= 0)
            {
                // Switch back to the assigned crystal target after timer ends.
                isAggroed = false;
                currTarget = spawnedBy;
            }
        }
    }


    public void ChangeSpeed(float amount)
    {
        this.speed += amount;
    }

    void MoveTowardsTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(-direction * speed * Time.deltaTime);
    }
    public void ReceiveDamage()
    {
        isAggroed = true;
        currTarget = target1.transform;
        aggroTimer = aggroTime;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        ReceiveDamage(); //Set up when collision between attack/ability hits enemy
        //Also here can set up when to stop moving (if hits body of crystal or player)
    }

}
