using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a script to handle the visuals of an enemy death
public class EnemyDeathHandler : MonoBehaviour
{
    private EnemyHealthPoints enemyHealth;

    
     private SpriteRenderer sr;
    [SerializeField] private Color deathColorTint;
    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealthPoints>();
        enemyHealth.OnDead.AddListener(OnHandleDeath);
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnHandleDeath()
    {
        StopMoving();
        StopAttacking();
        ChangeToDeathTint();
        StartCoroutine(ShrinkThenDie());
        //this is where you can change death anims or do other logic 
        //as a temp effect, it will freeze, stop shooting, turn red, shrink then destroy itself
    }

    private void StopAttacking()
    {
        EnemyAI enemyAi = GetComponent<EnemyAI>();
        enemyAi?.SetEnemyToIdle();
    }

    private void StopMoving()
    {
        Movement enemyMovement = GetComponent<EnemyAI>(); //hmmm i want the movement so i get the enemyAI? 
        enemyMovement?.SetSpeed(0);
    }

    private void ChangeToDeathTint()
    {
        sr.color = deathColorTint;
    }

    private IEnumerator ShrinkThenDie()
    {
        Transform enemyVisualTransform = sr.gameObject.transform;
        float shrinkTime = 0.5f;
        float currentScale = enemyVisualTransform.localScale.x; //assuming the scale x and y is the same. Raeus would probs change it tho just because 
        float targetScale = 0.01f;

        for (float i = 0.0f; i <= shrinkTime; i += Time.deltaTime)
        {
            float newScaleVal = Mathf.Lerp(currentScale, targetScale, i / shrinkTime);
            enemyVisualTransform.localScale = new Vector3(newScaleVal, newScaleVal, 0);
            yield return null;
        }

        Destroy(this.gameObject);
    }


}
