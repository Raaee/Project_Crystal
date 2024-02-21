using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{


    // list of interactable objects in range of the player

    public List<IInteractable> interactablesInRange = new List<IInteractable>();

    // private Actions actions;


    private void Awake()
    {
        // actions = GetComponent<Actions>();
        // actions.OnInteract.addListener();

    }

    private void InteractionDetected()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
    

    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {

    }




}
