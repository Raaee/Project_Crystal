using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour    {
    // list of interactable objects in range of the player
    private Actions actions;
    public List<IInteractable> interactablesInRange = new List<IInteractable>();

    private void Awake()    {
        actions = GetComponent<Actions>();
        actions.OnInteract.AddListener(InteractionDetected);
    }

    private void InteractionDetected()  {
        if (interactablesInRange.Count > 0) {
            IInteractable interactable = interactablesInRange[0];
            interactable.Interact();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable != null) {
            interactablesInRange.Add(interactable);
            interactable.HighlightSprite();
        }       
    }
    private void OnTriggerExit2D(Collider2D collision) {
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactablesInRange.Contains(interactable)) {
            interactablesInRange.Remove(interactable);
            interactable.NormalSprite();
        }
    }

}
