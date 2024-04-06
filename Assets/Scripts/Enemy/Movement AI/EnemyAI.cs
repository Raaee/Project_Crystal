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

public class EnemyAI : Movement {

    [SerializeField] private Transform player;
    [SerializeField] private Transform crystalObject;
    [SerializeField] private EnemyAIType enemyAIType;

    [Header("Config")]
    [SerializeField] private float playerAggroTime = 2f;
    [SerializeField] private float avoidTime = 1f;
    [SerializeField] private float attackRange;
    private EnemyHealthPoints enemyHP;
    private Transform currTarget;
    private RangedBasicAttack enemyRangedBasicAttack;

    [Header("Debug")]
    [SerializeField] private EnemyState enemyCurrentState;
    
    // Serialized Misc Variables
  //  private bool inDanger;

    private float currentAggroTimer;
    private bool isPlayerAggroActive = false;

    private float currentAvoidTimer;
    private bool isAvoidTimerActive = false;

    private bool isCrystalDeath = false;

    // Start() calls SetInitialTarget()
    private void Awake() {
        enemyHP = GetComponent<EnemyHealthPoints>();
        enemyRangedBasicAttack = GetComponentInChildren<RangedBasicAttack>();
    }
    public override void Start()    {
        base.Start();
        SetInitialTarget();
        enemyHP.OnHurt.AddListener(TargetPlayer);
        currentAggroTimer = playerAggroTime;
    }

    // SetInitialTarget(), if crystalObject is not null, sets currTarget to crystalObject and enemyCurrentState to MOVETOWARDSCRYSTAL
    // If crystalObject is null, enemyCurrentState is set to MOVETOWARDSPLAYER
    public void SetInitialTarget()  {
        player = PlayerManager.Instance.GetPlayer().transform;

        if (!crystalObject) {          
            IfNoPlayer();
        } 
        else if (!isCrystalDeath) {
            currTarget = crystalObject;
            enemyCurrentState = EnemyState.MOVETOWARDSCRYSTAL;
        }
    }

    private void IfNoPlayer()   {
        if (!player)    {
            Debug.LogError("No player in scene");
            enemyCurrentState = EnemyState.IDLE;
            return;
        }
        enemyCurrentState = EnemyState.MOVETOWARDSPLAYER;
    }

    // Update() calls two if statements and a single switch-case statement
    // The if statements check if isAvoidTimerActive/isAggroTimerActive are true and start a timer
    // enemyCurrentState is set to MOVETOWARDSCRYSTAL when timer reaches 0
    // The switch-case statement is repeatedly called to change enemyCurrentState to any of the states within the EnemyState enum it is set to
    private void Update()   {
        // Debug.Log(enemyCurrentState);
        if (isAvoidTimerActive)
        {
            currentAvoidTimer -= Time.deltaTime;
            if (currentAvoidTimer <= 0 && !isCrystalDeath)
            {
                enemyCurrentState = EnemyState.MOVETOWARDSCRYSTAL;
                isAvoidTimerActive = false;
            }
        }
        
        if (isPlayerAggroActive) {
            currentAggroTimer -= Time.deltaTime;
            if (currentAggroTimer <= 0 && !isCrystalDeath) {
                isPlayerAggroActive = false;
                enemyCurrentState = EnemyState.MOVETOWARDSCRYSTAL;
            }
        }

        switch (enemyCurrentState)  {
            case EnemyState.MOVETOWARDSCRYSTAL:
                SetInitialTarget();
                //currTarget = crystalObject;
                MoveTowardsTarget(currTarget);
                IfCrystalInRange();
                break;

            case EnemyState.MOVETOWARDSPLAYER:
                currTarget = player;
                isPlayerAggroActive = true;
                MoveTowardsTarget(currTarget);  
                IfPlayerInRange();
                break;

            case EnemyState.ATTACKINGCRYSTAL:
                // do attack
                FreezeEnemy();
                enemyRangedBasicAttack.AttackTarget(currTarget);
                break;

            case EnemyState.ATTACKINGPLAYER:
                FreezeEnemy();
                IfPlayerInRange();
                enemyRangedBasicAttack.AttackTarget(currTarget);
                // do attack
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
    public void TargetPlayer() {
        currentAggroTimer = playerAggroTime;
        enemyCurrentState = EnemyState.MOVETOWARDSPLAYER;
    }

    public void ListenCrystalDeath(Crystal curr)
    {
        curr.OnCrystalDie.AddListener(setCrystalDeath);
    }

    public void setCrystalDeath(){
        isCrystalDeath = true;
        enemyCurrentState = EnemyState.MOVETOWARDSPLAYER;
    }

    // InDanger() sets inDanger to true and checks if enemyAIType is AVOIDANT or HIVEMIND
    // Currently a useless method, but it is supposed to cause AVOIDANT enemies to flee when attacked by the Player
    // HIVEMIND enemies would not only aggro, but call nearby Enemies to fight alongside them against the Player
    //[com.cyborgAssets.inspectorButtonPro.ProButton]

    // INDANGER METHOD, similar to aggro. will be used for hivemind/avoidant AI.
    public void InDanger()
    {
       // inDanger = true;
        if (enemyAIType == EnemyAIType.AVOIDANT) {

        }
        else if (enemyAIType == EnemyAIType.HIVEMIND)
        {

        }
    }

    // INRANGE METHOD
    public void IfPlayerInRange() {
        if (attackRange >= Vector3.Distance(transform.position, player.transform.position)) {
            enemyCurrentState = EnemyState.ATTACKINGPLAYER;
        }
        else {
            enemyCurrentState = EnemyState.MOVETOWARDSPLAYER;
        }      
    }
    public void IfCrystalInRange() {
        if (!crystalObject) return;
        if (attackRange >= Vector3.Distance(transform.position, crystalObject.transform.position)) {
            enemyCurrentState = EnemyState.ATTACKINGCRYSTAL;
        }
    }
    public void SetCrystalObject(Transform transform) {
        crystalObject = transform;
    }

    public void SetEnemyToIdle()
    {
        enemyCurrentState = EnemyState.IDLE;
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
