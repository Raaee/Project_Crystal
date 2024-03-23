using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

// This class is responsible for handling the player's movement
public class PlayerMovement : MonoBehaviour
{

    // Reference to the player's input controls
    private InputControls playerInput;

    // The speed at which the player moves
    [SerializeField] private float moveSpeed = 10;

    // Reference to the player's Rigidbody2D component
    private Rigidbody2D rb2D;

    private Animator animator;

    // The current movement input from the player
    private Vector2 movementInput;

    // The smoothed movement input, used to make the player's movement feel more fluid
    private Vector2 smoothedMovementInput;

    // The current velocity of the movement input smoothing
    private Vector2 movementInputSmoothVelocity;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Get the Rigidbody2D component from the player
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Get the InputControls component from the player
        playerInput = GetComponent<InputControls>();
    }

    // FixedUpdate is called every fixed frame rate 
    private void FixedUpdate()
    {
        // Get the current movement input from the player
        movementInput = playerInput.movement.ReadValue<Vector2>();

        // Smooth the movement input over time
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, movementInput, ref movementInputSmoothVelocity, 0.1f);

        // Apply the movement input to the rb2D's velocity, scaled by the speed
        rb2D.velocity = smoothedMovementInput * moveSpeed;
    }

    // Method to get the current movement input
    public Vector2 GetMovementInput()
    {
        return movementInput;
    }
}

    








