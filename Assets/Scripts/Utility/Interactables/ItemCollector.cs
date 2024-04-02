using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour  {
    public static ItemCollector instance { get; private set; }
   
    [Header("Chest Stuff")]
    [Tooltip("Possible drops from chest")]
    [SerializeField] private List<GameObject> enemies;

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
        // This is for the mimic behavior:
        if (!DropManager.Instance.DropItems(transform)) {
            int ran = Random.Range(0, enemies.Count);
            Instantiate(enemies[ran], transform.position, Quaternion.identity);
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
