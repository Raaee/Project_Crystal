using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour  {

    public static ItemCollector instance { get; private set; }
    private GameObject objectCollected;

    [Header("Temp")]
    [SerializeField] private Sprite chestOpenSprite;

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
        objectCollected = go;
        DropData potentialDrop = GetComponent<DropData>();
        if (potentialDrop != null) {
            potentialDrop.OnDropInteract();
        }
        
        switch (type) {
            case InteractableType.HEALTH:
                HealthDropInteraction();
                break;
            case InteractableType.MANA:
                ManaDropInteraction();
                break;
            case InteractableType.BERSERK:
                BerserkDropInteraction();
                break;
            case InteractableType.CHEST:
                ChestInteraction();
                break;
            case InteractableType.CARROT:
                CarrotInteraction();
                break;
        }
    }
    public void HealthDropInteraction() {
        Debug.Log("Health pickup");
    }
    public void ManaDropInteraction() {
        Debug.Log("Mana pickup");
    }
    public void BerserkDropInteraction() {
        Debug.Log("Berserk pickup");
    }
    public void ChestInteraction() {
        Debug.Log("Chest pickup");
        objectCollected.GetComponent<SpriteRenderer>().sprite = chestOpenSprite;
    }
    public void CarrotInteraction() {
        // DO NOT TOUCH !! NO TOUCHY TOUCHY
        Debug.Log("Carrot pickup");
        GameObject go = GameObject.FindWithTag("Carrot");
        go.transform.parent = GameObject.FindWithTag("Player").transform;
        go.transform.position = go.transform.parent.GetChild(0).transform.position;        
    }
}
