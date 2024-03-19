using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicAttack : MonoBehaviour
{
    [SerializeField] private int baseDamage;
    private int curDamage;
    private HealthPoints curTarget;

    private void Start()
    {
        curDamage = baseDamage;
    }

    private void Update()
    {
        if (!curTarget.IsDead())
        {
            DoBasicAttack();
        }
    }

    public void DoBasicAttack()
    {
        curTarget.RemoveHealth(curDamage);
        // Perform a swing or shoot
    }
}
