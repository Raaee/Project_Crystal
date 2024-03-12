using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : Movement
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float aggroTime = 5f;
    [SerializeField] protected PriorityTarget priorityTarget;
    [SerializeField] protected EnemyAIType enemyAIType;
    [SerializeField] protected EnemyAttackType enemyAttackType;
    [SerializeField] protected EnemyState enemyCurrentState;
    [SerializeField] protected bool inDanger;
    [SerializeField] protected float attackRange;
    protected Transform crystalObject;
    protected bool isAggroed;
    protected Transform currTarget;

    private void Start()
    {
        priorityTarget = PriorityTarget.NONE;
        SetInitialTarget();
        enemyCurrentState = EnemyState.MOVETOWARDSCRYSTAL;

    }

    public void SetInitialTarget()
    {
        if (!crystalObject)
        {
            priorityTarget = PriorityTarget.NONE;
            return;
        }
        currTarget = crystalObject;
        priorityTarget = PriorityTarget.CRYSTAL;
    }

    private void Update()
    {

        switch (enemyCurrentState)
        {
            case EnemyState.MOVETOWARDSCRYSTAL:
                InRange();
                currTarget = crystalObject;
                MoveTowardsTarget(currTarget);

                break;

            case EnemyState.MOVETOWARDSPLAYER:
                InRange();
                currTarget = player;
                MoveTowardsTarget(currTarget);
                AggroToPlayer();
                break;

            case EnemyState.ATTACKINGCRYSTAL:
                InRange();
                break;

            case EnemyState.ATTACKINGPLAYER:
                InRange();
                break;

            case EnemyState.MOVEAWAY:
                //timer set up to temporarily use MoveAwayFromTarget
                break;

            case EnemyState.IDLE:
                priorityTarget = PriorityTarget.NONE;
                SetSpeed(0);
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
            enemyCurrentState = EnemyState.MOVETOWARDSCRYSTAL;
        }
    }

    // INDANGER METHOD, similar to aggro. will be used for hivemind/avoidant AI.
    public void InDanger()
    {
        inDanger = true;
        if (enemyAIType == EnemyAIType.AVOIDANT) {
            priorityTarget = PriorityTarget.NONE;
        }
        else if (enemyAIType == EnemyAIType.HIVEMIND)
        {
            priorityTarget = PriorityTarget.PLAYER;
        }
    }

    // INRANGE METHOD
    public void InRange()
    {
        if (attackRange >= Vector3.Distance(transform.position, currTarget.transform.position))
        {
            if (enemyCurrentState == EnemyState.MOVETOWARDSPLAYER)
            {
                enemyCurrentState = EnemyState.ATTACKINGPLAYER;
            }
            if (enemyCurrentState == EnemyState.MOVETOWARDSCRYSTAL)
            {
                enemyCurrentState = EnemyState.ATTACKINGCRYSTAL;
            }
        }
        else
        {
            if (enemyCurrentState == EnemyState.ATTACKINGPLAYER)
            {
                enemyCurrentState = EnemyState.MOVETOWARDSPLAYER;
            }
            if (enemyCurrentState == EnemyState.ATTACKINGCRYSTAL)
            {
                enemyCurrentState = EnemyState.MOVETOWARDSCRYSTAL;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        priorityTarget = PriorityTarget.PLAYER; //Set up when collision between attack/ability hits enemy
        //IF IN RANGE AND TAG IS ENEMY, CALL INDANGER. ON TRIGGER

        //if enemy curr state is MOVETOWARDSCRYSTAL
        //  enemy curr state = MOVETOWARDSPLAYER
        if (enemyCurrentState == EnemyState.MOVETOWARDSCRYSTAL) {
            enemyCurrentState = EnemyState.MOVETOWARDSPLAYER;
            InDanger();
        }

        
    }

}

public enum PriorityTarget{
    NONE,
    CRYSTAL,
    PLAYER
}

public enum EnemyAIType
{
    AVOIDANT,
    HIVEMIND,
    NONE
}

public enum EnemyAttackType
{
    MELEE,
    RANGED
}

public enum EnemyState
{
    MOVETOWARDSPLAYER,
    ATTACKINGPLAYER,
    MOVETOWARDSCRYSTAL,
    ATTACKINGCRYSTAL,
    MOVEAWAY,
    IDLE
}
