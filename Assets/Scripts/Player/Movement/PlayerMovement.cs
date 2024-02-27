using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    private InputControls playerInput;

    [SerializeField] private float moveSpeed = 10;
    private Rigidbody2D rigidbody;
    private Vector2 movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity; 
    
    private void Awake()    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<InputControls>();
    }
    private void FixedUpdate()  {
        // Get the current movement input from the player
        movementInput = playerInput.movement.ReadValue<Vector2>();
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, movementInput, ref movementInputSmoothVelocity, 0.1f);

        // Apply the movement input to the rigidbody's velocity, scaled by the speed
        rigidbody.velocity = smoothedMovementInput * moveSpeed;

    }
    public Vector2 GetMovementInput()   {
        return movementInput;
    }
}

    








