using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
  <summary> 
  - Explain what the script is doing

        EnemyAI derives from the abstract class Movement and begins by calling the SetInitialTarget() method. Depending on the enemyCurrentState,
    the Enemy will change from various states within the enum EnemyState which affects its movement.

  - Purpose for the script

        This script sets up the complex AI for Enemy movement, whether the Enemy is targeting the Crystal or Player
    and how it moves in relation to those targets in specific situations.

  - Code change suggestions

    - 
  </summary>
*/

public class EnemyAI : Movement
{
    // Serialized Target Variables
    [SerializeField] private Transform player;
    [SerializeField] private Transform crystalObject;

    // Serialized Time Start Variables
    [SerializeField] private float aggroTime = 2f;
    [SerializeField] private float avoidTime = 1f;

    //Serialized Enum Variables
    [SerializeField] private EnemyAIType enemyAIType;
    [SerializeField] private EnemyAttackType enemyAttackType;
    [SerializeField] private EnemyState enemyCurrentState;
    
    // Serialized Misc Variables
    [SerializeField] private bool inDanger;
    [SerializeField] private float attackRange;

    // 
    private Transform currTarget;
    private float currentAggroTimer;
    private bool isAggroTimerActive = false;
    private float currentAvoidTimer;
    private bool isAvoidTimerActive = false;

    // Start() calls SetInitialTarget()
    private void Start()
    {

        SetInitialTarget();
    }

    // SetInitialTarget(), if crystalObject is not null, sets currTarget to crystalObject and enemyCurrentState to MOVETOWARDSCRYSTAL
    // If crystalObject is null, enemyCurrentState is set to MOVETOWARDSPLAYER
    public void SetInitialTarget()
    {
        if (!crystalObject)
        {
            enemyCurrentState = EnemyState.MOVETOWARDSPLAYER;
            return;
        }
        currTarget = crystalObject;

        enemyCurrentState = EnemyState.MOVETOWARDSCRYSTAL;
    }

    // Update() calls two if statements and a single switch-case statement
    // The if statements check if isAvoidTimerActive/isAggroTimerActive are true and start a timer
    // enemyCurrentState is set to MOVETOWARDSCRYSTAL when timer reaches 0
    // The switch-case statement is repeatedly called to change enemyCurrentState to any of the states within the EnemyState enum it is set to
    private void Update()
    { 
        if (isAvoidTimerActive)
        {
            currentAvoidTimer -= Time.deltaTime;
            if (currentAvoidTimer <= 0)
            {
                enemyCurrentState = EnemyState.MOVETOWARDSCRYSTAL;
                isAvoidTimerActive = false;
            }
        }
        if (isAggroTimerActive)
        {
            currentAggroTimer -= Time.deltaTime;
            if (currentAggroTimer <= 0)
            {
                enemyCurrentState = EnemyState.MOVETOWARDSCRYSTAL;
                isAggroTimerActive = false;
            }
        }
        switch (enemyCurrentState)
        {
            case EnemyState.MOVETOWARDSCRYSTAL:
                currTarget = crystalObject;
                MoveTowardsTarget(currTarget);
                break;

            case EnemyState.MOVETOWARDSPLAYER:
                currTarget = player;
                MoveTowardsTarget(currTarget);
                currentAggroTimer = aggroTime;
                isAggroTimerActive = true;
                break;

            case EnemyState.ATTACKINGCRYSTAL:
                break;

            case EnemyState.ATTACKINGPLAYER:
                break;

            case EnemyState.MOVEAWAY:
                //timer set up to temporarily use MoveAwayFromTarget
                MoveAwayFromTarget(player);
                currentAvoidTimer = avoidTime;
                isAvoidTimerActive = true;
                break;

            case EnemyState.IDLE:
                SetSpeed(0);
                break;
        }
    }

    // InDanger() sets inDanger to true and checks if enemyAIType is AVOIDANT or HIVEMIND
    // Currently a useless method, but it is supposed to cause AVOIDANT enemies to flee when attacked by the Player
    // HIVEMIND enemies would not only aggro, but call nearby Enemies to fight alongside them against the Player
    public void InDanger()
    {
        inDanger = true;
        if (enemyAIType == EnemyAIType.AVOIDANT) {

        }
        else if (enemyAIType == EnemyAIType.HIVEMIND)
        {

        }
    }

    // InRange() checks if the Enemy's distance from a target surpasses attackRange
    // If attackRange is surpassed, the Enemy switches to ATTACKINGPLAYER/CRYSTAL if it was previously MOVETOWARDSPLAYER/CRYSTAL respectively
    // If attackRange is not surpassed and the Enemy is in ATTACKINGPLAYER/CRYSTAL, then it reverts to MOVINGTOWARDSPLAYER/CRYSTAL respectively
    /*
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
    */

    // OnCollisionEnter2D() checks if enemyCurrentState is MOVETOWARDSCRYSTAL
    // If true, it sets that state to MOVETOWARDSPLAYERS and calls InDanger()
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemyCurrentState == EnemyState.MOVETOWARDSCRYSTAL) {
            enemyCurrentState = EnemyState.MOVETOWARDSPLAYER;
            InDanger();
        }
    }

}

// EnemyAIType can be set to AVOIDANT, HIVEMIND, or IDLE
// AVOIDANTs will contain behavior where they run from the Player
// HIVEMINDs will contain behavior wherein they call the for the aid of nearby Enemies
// IDLEs behave normally
public enum EnemyAIType
{
    AVOIDANT,
    HIVEMIND,
    NONE
}

// EnemyAttackType can be set to MELEE or RANGE
// Movement-wise, this enum is needed to determine the attackRange value
public enum EnemyAttackType
{
    MELEE,
    RANGED
}

// EnemyState can be set to MOVETOWARDSPLAYER, ATTACKINGPLAYER, MOVETOWARDSCRYSTAL, ATTACKINGCRYSTAL, MOVEAWAY, or IDLE
// MOVETOWARDSPLAYER and MOVETOWARDSCRYSTAL will move the Enemy to the Player or Crystal respectively
// ATTACKINGPLAYER and ATTACKINGCRYSTAL will stop the Enemy and activate some sort of attack method against the Player or Crystal respectively
// MOVEAWAY will be called to move the Enemy away from the Player
// IDLE will make the Enemy stationary
public enum EnemyState
{
    MOVETOWARDSPLAYER,
    ATTACKINGPLAYER,
    MOVETOWARDSCRYSTAL,
    ATTACKINGCRYSTAL,
    MOVEAWAY,
    IDLE
}
