using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDropper : MonoBehaviour {

public List<GameObject> enemyDrop;
[SerializeField] private GameObject allDropsParentGO;

private EnemyHealthPoint enemyHealthPoint;

void Start(){
    enemyHealthPoint = GetComponent<EnemyHealthPoint>();
    enemyHealthPoint.OnDeath.AddListener(ItemDrop);
}
    public void ItemDrop() {
        bool somethingDropped = false;
        float draw = Random.Range(0f, 100f);
        Debug.Log("Random draw: "+ draw);

        foreach (GameObject drop in enemyDrop) {
            if (draw <= drop.GetComponent<Drop>().GetDropChance()) {
                GameObject go = Instantiate(drop, this.transform.position, Quaternion.identity);
                go.transform.parent = allDropsParentGO.transform;
                Debug.Log(go);
                somethingDropped = true;
            }           
        }

    }

}

