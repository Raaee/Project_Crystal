using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script for handling the enemy visuals
/// </summary>
public class EnemyAnimation : MonoBehaviour
{
    [Header("Enemy Visual Configs")]
    [SerializeField] private SpriteRenderer enemySpriteRenderer;
    [SerializeField] private Animator enemyAnim;
  
   //helper components
    private EnemyAI enemyAI;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }


    private void Update()
    {
            enemySpriteRenderer.flipX = enemyAI.GetMovementState() == MovementState.LEFT;     
    }

}
