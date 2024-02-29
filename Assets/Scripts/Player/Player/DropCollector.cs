using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollector : MonoBehaviour

{
    private void Start()
    {
        Debug.Log("Starting drop collector system");
    }

  void OnTriggerEnter2D(Collider2D col)
    {
        
        DropData potentialDrop = col.gameObject.GetComponent<DropData>();
        if (potentialDrop != null) {
        Debug.Log(col.gameObject);
        GameObject playerGameObject = col.gameObject.transform.gameObject;
        Debug.Break();
        potentialDrop.setPlayerGameObject(playerGameObject);
        potentialDrop.OnDropInteract();
        }
        else
        {
            Debug.Log(col.name + " doesn't have a potential drop.");
        }
    }


}
