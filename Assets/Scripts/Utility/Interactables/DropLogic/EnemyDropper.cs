using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDropper : MonoBehaviour
{

    [SerializeField] [Range(0.01f, 0.99f)] private float lootDropChance = 0.35f;

    private EnemyHealthPoints enemyHealthPoints;
    private const float MAX_RANGE = 1.0f;
    private const float MIN_RANGE = 0.01f;
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
        float randomFloat = Random.Range(MIN_RANGE, MAX_RANGE);
        //do nothing if you fall under the drop chance 
        if (randomFloat > lootDropChance)
            return;

        //get the drop manager to give you a drop. currently hardcoded to 50% mana or health 

        if (randomFloat > ((MAX_RANGE - MIN_RANGE) / 2))
        {
            DropManager.Instance?.GetManaDrop(transform.position);
        }
        else
        {
            DropManager.Instance?.GetHealthDrop(transform.position);
        }

    }

}

