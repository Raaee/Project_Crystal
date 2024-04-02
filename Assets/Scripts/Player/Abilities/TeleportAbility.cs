using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

// This class represents the Teleport ability for a player in a game.
public class TeleportAbility : Ability
{
    // The distance the player can teleport.
    [SerializeField] private float teleportDistance;
    // The Actions component of the player.
    private Actions actions;
    // The PlayerMovement component of the player.
    private PlayerMovement playerMovement;
    // The current movement input of the player.
    private Vector2 movementInput;
    [HideInInspector] public UnityEvent<Vector2> OnTeleport;

    
    private void Start()
    {
        // Get the Actions and PlayerMovement components from the parent object.
        actions = GetComponentInParent<Actions>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        // Add the Teleport method as a listener to the OnTeleport event.
        actions.OnTeleport.AddListener(Teleport);
    }

    
    private void FixedUpdate()
    {
        // Get the current movement input of the player.
        movementInput = playerMovement.GetMovementInput();
    }

    // This method is used to teleport the player.
    public void Teleport()
    {
        // If the ability is on cooldown, return.
        if (isOnCoolDown)
            return;

        // Start the UseAbility coroutine.
        StartCoroutine(UseAbility());
    }

    // This method is called when the ability is used.
    public override void AbilityUsage()
    {
        // Log that the teleport ability was used and the current movement input.
        Debug.Log("Teleport Used!" + movementInput);
        // Move the player's position by the movement input multiplied by the teleport distance.
        playerMovement.gameObject.transform.position += (Vector3)movementInput * teleportDistance;
        OnTeleport?.Invoke(movementInput);
    }
}
