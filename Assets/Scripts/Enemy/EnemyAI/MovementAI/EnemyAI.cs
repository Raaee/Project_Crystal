using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : Movement
{
    private PriorityTarget priorityTarget;
    private GameObject player;
    private Transform spawnedBy;
    protected bool isAggroed;
    [SerializeField] private float aggroTime = 5f;
    private Transform currTarget;

    private void Start()
    {
        priorityTarget = PriorityTarget.IDLE;
        SetInitialTarget();
    }

    public void SetInitialTarget()
    {
        if (spawnedBy != null)
        {
            currTarget = spawnedBy;
        }
    }

    private void Update()
    {
        switch (priorityTarget)
        {
            case PriorityTarget.IDLE:
                SetSpeed(0);
                break;
            case PriorityTarget.CRYSTAL:
                SetSpeed(baseSpeed);
                break;
            case PriorityTarget.PLAYER:
                SetSpeed(baseSpeed);
                Aggro();
                break;
            case PriorityTarget.NONE:
                //Avoidant
                SetSpeed(baseSpeed);
                break;
        }
    }

    //[com.cyborgAssets.inspectorButtonPro.ProButton]
    public void Aggro()
    {
        isAggroed = true;
        currTarget = player.transform;
        AggroTimer(aggroTime);
    }
    public void AggroTimer(float aggroTimer)
    {
        aggroTimer -= Time.deltaTime;
        if (aggroTimer <= 0)
        {
            // Switch back to the assigned crystal target after timer ends.
            isAggroed = false;
            currTarget = spawnedBy;
            priorityTarget = PriorityTarget.CRYSTAL;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        priorityTarget = PriorityTarget.PLAYER; //Set up when collision between attack/ability hits enemy
        //Also here can set up when to stop moving (if hits body of crystal or player)
        // SetSpeed(0) until out of range
        // Or disable MoveTowardsTarget, set target to null?
    }

}

public enum PriorityTarget{
    IDLE,
    CRYSTAL,
    PLAYER,
    NONE
}
