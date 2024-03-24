using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This class represents the Piercing Shot ability for a player character.
public class PiercingShotAbility : Ability
{
    // Serialized fields for Unity inspector
    [SerializeField] private GameObject rangedAbility1Prefab;
    [SerializeField] private ObjectPooler projPooler;
    [SerializeField] float delayBetweenPresses = 0.25f;

    // Private fields
    private Actions actions;
    private InputControl playerInput;
    private bool KeyPress = true;
    private bool pressedFirstTime = false;
    private float lastPressedTime;

    void Awake()
    {
        // Get the Actions component from the parent object
        actions = GetComponentInParent<Actions>();

        // If Actions component is not found, log an error and break
        if (actions == null)
        {
            Debug.LogError("Actions not found");
            Debug.Break();
        }

        // Add ShootIfActive method as a listener to OnAbility1 event
        actions.OnAbility1.AddListener(ShootIfActive);
    }

    // Method to spawn a projectile in a given direction
    public void SpawnProjectile(Vector2 moveDirection)
    {
        // Get a pooled object and set its position and direction
        GameObject go = projPooler.GetPooledObject();
        go.transform.position = this.transform.position;
        PiercingProjectile projectile = go.GetComponent<PiercingProjectile>();
        projectile.SetMoveDirection(moveDirection);
        go.SetActive(true);
    }

    // Method to shoot if the ability is active
    public void ShootIfActive()
    {
        // If the current mana is greater than or equal to the mana cost, use the ability
        if (GetCurrentMana() >= manaCost)
            StartCoroutine(UseAbility());
    }

    // Overridden method for ability usage
    public override void AbilityUsage()
    {
        // Calculate the direction from the object to the mouse position and spawn a projectile in that direction
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 direction = (mousePosition - objectPosition).normalized;
        SpawnProjectile(direction);
    }

    // Method to confirm a double press
    public void ConfirmDoublePress()
    {
        // If the key is pressed
        if (KeyPress)
        {
            // If the key was already pressed once
            if (pressedFirstTime)
            {
                // Check if the second press is fast enough to be considered a double press
                bool isDoublePress = Time.time - lastPressedTime <= delayBetweenPresses;

                // If it is a double press
                if (isDoublePress)
                {
                    Debug.Log("DoublePress");

                    // If the ability is on cooldown, return
                    if (isOnCoolDown)
                        return;

                    // Use the ability and reset the first press flag
                    StartCoroutine(UseAbility());
                    pressedFirstTime = false;
                }
            }
            else // If the key was not already pressed once
            {
                // Set the first press flag
                pressedFirstTime = true;
            }

            // Update the last pressed time
            lastPressedTime = Time.time;
        }

        // If we're waiting for a second key press but we've reached the delay, reset the first press flag
        if (pressedFirstTime && Time.time - lastPressedTime > delayBetweenPresses)
        {
            pressedFirstTime = false;
        }
    }
}
