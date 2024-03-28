using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour  {
    public static ItemCollector instance { get; private set; }
    private GameObject objectCollected;
    private GameObject allDropsParentGO;

    [Header("Chest Stuff")]
    [Tooltip("Possible drops from chest")]
    [SerializeField] private List<GameObject> chestDrops;
    [SerializeField] private Sprite chestOpenSprite;
    [SerializeField] private Sprite chestClosedSprite;
    [SerializeField] private float respawnTime = 3f;
    [SerializeField] private float disappearTime = 1f;

    private void Awake() {
        Init();
    }
    private void Init() {
        allDropsParentGO = new GameObject("All drops Parent");

        if (instance != null && instance != this) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }
    public void Interact(InteractableType type, GameObject go) {
      
        objectCollected = go;
        DropData potentialDrop = go.GetComponent<DropData>();
        if (potentialDrop != null) {
            potentialDrop.OnDropInteract();
        }
        
        switch (type) {
            case InteractableType.CHEST:
                ChestInteraction();
                break;
            case InteractableType.CARROT:
                CarrotInteraction();
                break;
        }
    }
    public void ChestInteraction() {
        bool somethingDropped = false;
        float draw = Random.Range(0f, 100f);
      

        foreach (GameObject drop in chestDrops) {
            if (draw <= drop.GetComponent<Drop>().GetDropChance()) {
                GameObject go = Instantiate(drop, this.transform.position, Quaternion.identity);
                go.transform.parent = allDropsParentGO.transform;
                Debug.Log(go);
                somethingDropped = true;
            }           
        }
        // This is for the mimic behavior:
        if (!somethingDropped) {
            Debug.Log("************ Enemy spawned");
        }
        StartCoroutine(ChestOpenVisual(objectCollected));
    }
    public IEnumerator ChestOpenVisual(GameObject obj) {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        sr.sprite = chestOpenSprite;
        yield return new WaitForSeconds(disappearTime);
        obj.SetActive(false);
        StartCoroutine(RespawnChest(sr, obj));
    }
    public IEnumerator RespawnChest(SpriteRenderer sr, GameObject obj) {
        yield return new WaitForSeconds(respawnTime);
        sr.sprite = chestClosedSprite;
        obj.SetActive(true);
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
