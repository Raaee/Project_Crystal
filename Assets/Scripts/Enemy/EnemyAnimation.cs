using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Script for handling the enemy visuals
/// </summary>
public class EnemyAnimation : MonoBehaviour
{
    [Header("Enemy Visual Configs")]
    [SerializeField] private GameObject enemyVisual;
    [SerializeField] private Canvas hpBarCanvas;
    [SerializeField] private Image hpEnemyFilling;
    [SerializeField] private HealthPoints hp;
    private AnimationControl animControl;

  
   //helper components
    private EnemyAI enemyAI;
    private RangedBasicAttack rangedBA;

    private void Start()
    {
        enemyAI = GetComponentInParent<EnemyAI>();
        hpBarCanvas.enabled = false;
        hp.OnHurt.AddListener(UpdateEnemyHealth);
        rangedBA = this.transform.parent.GetComponentInChildren<RangedBasicAttack>();
        animControl = GetComponent<AnimationControl>();
        hpBarCanvas.worldCamera = FindFirstObjectByType<Camera>();
        rangedBA.OnAttack.AddListener(PlayAttack);

    }
    public void PlayAttack() {
        animControl.PlayAttack();
    }
    
    private void Update()
    {
        // enemySpriteRenderer.flipX = enemyAI.GetMovementState() == MovementState.LEFT; 
        
        if (enemyAI.GetMovementState() == MovementState.LEFT) {
            enemyVisual.transform.rotation = Quaternion.Euler(0, -180, 0);
        } else {
            enemyVisual.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void UpdateEnemyHealth() {
        hpBarCanvas.enabled = true;
        hpEnemyFilling.fillAmount = (float) hp.currentHP / hp.maxHP;
       

    }


}
