using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour  {
    public static ItemCollector instance { get; private set; }
   
    [Header("Chest Stuff")]
    [Tooltip("Possible drops from chest")]
    [SerializeField] private List<GameObject> chestDrops;
   

    private void Awake() {
        Init();
    }
    private void Init() {
      

        if (instance != null && instance != this) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }
    public void Interact(InteractableType type, GameObject go) {
      
        DropData potentialDrop = go.GetComponent<DropData>();
        if (potentialDrop != null) {
            potentialDrop.OnDropInteract();
        }
        
        switch (type) {
            case InteractableType.CHEST:
                ChestInteraction(go);
                break;
            case InteractableType.CARROT:
                CarrotInteraction();
                break;
        }
    }
    public void ChestInteraction(GameObject chestGO) {
        bool somethingDropped = false;
        float draw = Random.Range(0f, 100f);
      

        foreach (GameObject dropPrefab in chestDrops) {
            Drop drop = dropPrefab.GetComponent<Drop>();
            Debug.Log("draw: " + draw);
            Debug.Log("drop chance: " + drop.GetDropChance());

            if (draw <= drop.GetDropChance()) {
                //GameObject go = Instantiate(drop, this.transform.position, Quaternion.identity);
                // go.transform.parent = allDropsParentGO.transform;
                //Debug.Log(go);

                float randomOffset = Random.Range(1f,1f); //adding a random offset its not spawned right on chest
                Vector3 spawnLocation = new Vector3(transform.position.x + randomOffset, transform.position.y + randomOffset, 0);
                switch(drop.GetInteractableType())
                {
                    case InteractableType.HEALTH:
                        DropManager.Instance?.GetHealthDrop(spawnLocation);
                        break;
                    case InteractableType.MANA:
                        DropManager.Instance?.GetManaDrop(spawnLocation);
                        break;
                }
                somethingDropped = true;
            }           
        }
        // This is for the mimic behavior:
        if (!somethingDropped) {
            Debug.Log("************ Enemy spawned");
        }
     
        ChestVisual chestVisual = chestGO.GetComponent<ChestVisual>();
        if (chestVisual)
            StartCoroutine(chestVisual.ChestOpenVisual());
    }
   
    public void CarrotInteraction() { 
        // DO NOT TOUCH !! NO TOUCHY TOUCHY
        Debug.Log("Carrot pickup");
        GameObject go = GameObject.FindWithTag("Carrot");
        go.transform.parent = GameObject.FindWithTag("Player").transform;
        go.transform.SetSiblingIndex(1);
        go.transform.position = go.transform.parent.GetChild(0).transform.position;
    }
}
