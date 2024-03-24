using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollector : MonoBehaviour

{
    private void Start()
    {
        Debug.Log("Starting drop collector system");
    }

  void OnTriggerEnter2D(Collider2D potentialDropCollider)
    {
        
        DropData potentialDrop = potentialDropCollider.gameObject.GetComponent<DropData>();
        if (potentialDrop != null) {

    
        GameObject playerGameObject = gameObject.transform.parent.gameObject;
        
        potentialDrop.setPlayerGameObject(playerGameObject);
        potentialDrop.OnDropInteract();
        }
        else
        {
            Debug.Log(potentialDropCollider.name + " doesn't have a potential drop.");
        }
    }


}
