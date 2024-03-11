using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] private float baseSpeed;
    [SerializeField] private float maxSpeed;
    private float curSpeed;
    private GameObject player;
    private Transform spawnedBy;
    private bool isAggroed;
    [SerializeField] private float aggroTime = 5f;
    private float aggroTimer = 0f;
    private Transform currTarget;

    public void Start()
    {
        SetInitialTarget();
        curSpeed = baseSpeed;
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


    public void SetSpeed(float amount)
    {
        this.curSpeed = amount;
        //After duration of speed amp/nerf is over, Ienumerators
        this.curSpeed = baseSpeed;
    }

    void MoveTowardsTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(-direction * curSpeed * Time.deltaTime);
    }
    [com.cyborgAssets.inspectorButtonPro.ProButton]
    public void Aggro()
    {
        isAggroed = true;
        currTarget = player.transform;
        aggroTimer = aggroTime;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Aggro(); //Set up when collision between attack/ability hits enemy
        //Also here can set up when to stop moving (if hits body of crystal or player)
        // SetSpeed(0) until out of range
        // Or disable MoveTowardsTarget, set target to null?
    }

}
