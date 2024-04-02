using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DropManager : MonoBehaviour
{
    public static DropManager Instance;

    [SerializeField] private List<GameObject> possibleDrops;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("More than one Drop Manager in this Scene!");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    public bool DropItems(Transform parentPos) {
        bool somethingDropped = false;
        float draw = Random.Range(0f, 100f);

        foreach (GameObject dropPrefab in possibleDrops) {
            Drop drop = dropPrefab.GetComponent<Drop>();
            if (draw <= drop.GetDropChance()) {
                float randomOffset = Random.Range(0.5f, 1.5f); //adding a random offset its not spawned right on chest
                Vector3 spawnLocation = new Vector3(parentPos.position.x + randomOffset, parentPos.position.y + randomOffset, 0);
                switch (drop.GetInteractableType()) {
                    case InteractableType.HEALTH:
                        GetHealthDrop(spawnLocation);
                        break;
                    case InteractableType.MANA:
                        GetManaDrop(spawnLocation);
                        break;
                    case InteractableType.BERSERK:
                        GetBerserkDrop(spawnLocation);
                        break;
                }
                somethingDropped = true;
            }
        }
        return somethingDropped;
    }

    public GameObject GetManaDrop(Vector3 location) {
        GameObject go = Instantiate(GetDropObj(InteractableType.MANA), location, Quaternion.identity);
        return go; //return not really needed, the method abouve spawns and sets the drop
    }
    public GameObject GetHealthDrop(Vector3 location)   {
        GameObject go = Instantiate(GetDropObj(InteractableType.HEALTH), location, Quaternion.identity);
        return go;
    }
    public GameObject GetBerserkDrop(Vector3 location) {
        GameObject go = Instantiate(GetDropObj(InteractableType.BERSERK), location, Quaternion.identity);
        return go;
    }
    public GameObject GetDropObj(InteractableType type) {        
        return possibleDrops.First(drop => drop.GetComponent<Drop>().GetInteractableType() == type);
    }


}
