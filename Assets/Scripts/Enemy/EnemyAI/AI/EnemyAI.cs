using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : Movement
{
    [Header("Config")]
    [SerializeField] private float playerAggroTime = 2f;
    [SerializeField] private float avoidTime = 1f;
    [SerializeField] private EnemyAttackType enemyAttackType;
    [SerializeField] private float attackRange;
    private EnemyHealthPoints enemyHP;
    private Transform currTarget;
    private RangedBasicAttack enemyRangedBasicAttack;

    [Header("Debug")]
    [SerializeField] private Transform player;
    public Transform crystalObject;
    [SerializeField] private EnemyAIType enemyAIType;
    [SerializeField] private EnemyState enemyCurrentState;
    [SerializeField] private bool inDanger;

    public float currentAggroTimer;
    public bool isPlayerAggroActive = false;

    private float currentAvoidTimer;
    private bool isAvoidTimerActive = false;
    private const string PLAYER_TAG = "Player";

    private void Awake() {
        enemyHP = GetComponent<EnemyHealthPoints>();
        enemyRangedBasicAttack = GetComponentInChildren<RangedBasicAttack>();
    }
    private void Start()
    {
        base.Start();
        SetInitialTarget();
        enemyHP.OnHurt.AddListener(TargetPlayer);
        currentAggroTimer = playerAggroTime;

    }

    private void SetInitialTarget()
    {
        player = GameObject.FindWithTag(PLAYER_TAG).transform;

        if (!crystalObject) {          
            IfNoPlayer();
        } 
        else {
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

    private void Update()   {
        if (isPlayerAggroActive) {
            currentAggroTimer -= Time.deltaTime;
            if (currentAggroTimer <= 0) {
                isPlayerAggroActive = false;
                enemyCurrentState = EnemyState.MOVETOWARDSCRYSTAL;
            }
        }
        switch (enemyCurrentState)
        {
            case EnemyState.MOVETOWARDSCRYSTAL:
                currTarget = crystalObject;
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
                enemyRangedBasicAttack.AttackTarget(currTarget);
                break;

            case EnemyState.ATTACKINGPLAYER:
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
    //[com.cyborgAssets.inspectorButtonPro.ProButton]

    // INDANGER METHOD, similar to aggro. will be used for hivemind/avoidant AI.
    public void InDanger()
    {
        inDanger = true;
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
        if (attackRange >= Vector3.Distance(transform.position, crystalObject.transform.position)) {
            enemyCurrentState = EnemyState.ATTACKINGCRYSTAL;
        }
    }
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
