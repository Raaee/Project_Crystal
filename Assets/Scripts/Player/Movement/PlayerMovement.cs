using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rigidbody;
    private Vector2 movementInput;
    private InputControls playerInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity; 
    
    private void Awake()
    {
        rigidbody ??= GetComponent<Rigidbody2D>();
        playerInput = GetComponent<InputControls>();
        
        gameObject.GetComponent<TrailRenderer>().enabled = false;
        // If there's no PlayerInput component attached, add one
        if (playerInput == null)
        {
            playerInput = gameObject.AddComponent<InputControls>();
        }
    }
    private void FixedUpdate()
    {
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, movementInput, ref movementInputSmoothVelocity, 0.1f);
        // Get the current movement input from the player
        movementInput = playerInput.movement.ReadValue<Vector2>();

        // Apply the movement input to the rigidbody's velocity, scaled by the speed
        rigidbody.velocity = smoothedMovementInput * speed;
    }
    public Vector2 GetMovementInput()
    {
        return movementInput;
    }
}

    








