using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleportAbility1 : Ability
{
    [SerializeField] private float teleportDistance;
    private PlayerMovement playerMovement;
    private Vector2 movementInput;
   

    private void Start()
    {
        actions = GetComponent<Actions>();
        playerMovement = GetComponent<PlayerMovement>();
        actions.OnTeleport.AddListener(Teleport);
    }

    private void FixedUpdate()
    {
        movementInput = playerMovement.GetMovementInput();
    }

    public void Teleport()
    {
        if (isOnCoolDown)
            return;

        
        StartCoroutine(UseAbility());

    }
    public override void AbilityUsage()
    {

        transform.position += (Vector3)movementInput * teleportDistance;
        
    }
}
