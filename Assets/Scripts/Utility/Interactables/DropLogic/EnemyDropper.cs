using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDropper : MonoBehaviour
{
    private EnemyHealthPoints enemyHealthPoints;
    void Start()    
    {
        enemyHealthPoints = GetComponent<EnemyHealthPoints>();
        enemyHealthPoints.OnDead.AddListener(LootDrop);
        if(DropManager.Instance == null)
        {
            Debug.LogError("There Should be a drop manager in the scene");
        }
    }
    // Enemy will randomly drop a loot item, it also has a chance to drop nothing at all
    public void LootDrop() 
    {
        DropManager.Instance?.DropItems(transform);
    }

}

