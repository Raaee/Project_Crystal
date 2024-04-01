using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script for handling the enemy visuals
/// </summary>
public class EnemyAnimation : AnimationControl
{
    [Header("Enemy Visual Configs")]
    [SerializeField] private SpriteRenderer enemySpriteRenderer;
  
   //helper components
    private EnemyAI enemyAI;
    private RangedBasicAttack rangedBA;

    private void Start()
    {
        enemyAI = GetComponentInParent<EnemyAI>();
        rangedBA = this.transform.parent.GetComponentInChildren<RangedBasicAttack>();
        //rangedBA.OnAttack.AddListener(PlayAttack);
    }

    private void Update()
    {
            enemySpriteRenderer.flipX = enemyAI.GetMovementState() == MovementState.LEFT; 
    }

}
