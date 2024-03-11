using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : Movement
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float aggroTime = 5f;
    protected PriorityTarget priorityTarget;
    protected Transform crystalObject;
    protected bool isAggroed;
    protected Transform currTarget;
    //private bool inDanger;

    private void Start()
    {
        priorityTarget = PriorityTarget.IDLE;
        SetInitialTarget();
    }

    public void SetInitialTarget()
    {
        if (!crystalObject)
        {
            priorityTarget = PriorityTarget.IDLE;
            return;
        }
        currTarget = crystalObject;
        priorityTarget = PriorityTarget.CRYSTAL;
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
                currTarget = crystalObject;
                break;
            case PriorityTarget.PLAYER:
                SetSpeed(baseSpeed);
                currTarget = player;
                AggroToPlayer();
                break;
            case PriorityTarget.NONE:
                //Avoidant
                SetSpeed(baseSpeed);
                MoveAwayFromTarget(player);
                break;
        }
    }

    //[com.cyborgAssets.inspectorButtonPro.ProButton]
    public void AggroToPlayer()
    {
        isAggroed = true;
        AggroTimer(aggroTime);
    }
    public void AggroTimer(float aggroTimer)
    {
        aggroTimer -= Time.deltaTime;
        if (aggroTimer <= 0)
        {
            // Switch back to the assigned crystal target after timer ends.
            isAggroed = false;
            priorityTarget = PriorityTarget.CRYSTAL;
        }
    }

    // INDANGER METHOD, similar to aggro. will be used for hivemind/avoidant AI.

    void OnCollisionEnter2D(Collision2D collision)
    {
        priorityTarget = PriorityTarget.PLAYER; //Set up when collision between attack/ability hits enemy
        //IF IN RANGE AND TAG IS ENEMY, SET INDANGER TO TRUE

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
