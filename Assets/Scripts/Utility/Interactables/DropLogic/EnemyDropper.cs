using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDropper : MonoBehaviour{

    public List<GameObject> enemyDrop;
    private GameObject allDropsParentGO;

    private EnemyHealthPoints enemyHealthPoints;

    void Start()    {
        allDropsParentGO = GameObject.FindWithTag("DropsParent");
        enemyHealthPoints = GetComponent<EnemyHealthPoints>();
        enemyHealthPoints.OnDead.AddListener(ItemDrop);
    }
    public void ItemDrop() {
        float draw = Random.Range(0f, 100f);

        foreach (GameObject drop in enemyDrop) {
            if (draw <= drop.GetComponent<Drop>().GetDropChance()) {
                GameObject go = Instantiate(drop, this.transform.position, Quaternion.identity);
                go.transform.parent = allDropsParentGO.transform;
                Debug.Log(go);
            }           
        }

    }

}

