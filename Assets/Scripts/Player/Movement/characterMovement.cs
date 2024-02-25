using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rigidbody;
    private Vector2 movementInput;
    private InputInitialize playerInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;
    private float activeMoveSpeed;
    private float dashSpeed;
    public float dashLength = 0.5f, dashCoolDown = 1f;
    private float dashCounter;
    private float dashCoolCounter;
    public event Action<float> OnDash;
    private bool isDashing;

    private void Awake()
    {
        rigidbody ??= GetComponent<Rigidbody2D>();
        playerInput = GetComponent<InputInitialize>();
        activeMoveSpeed = speed;
        

        // If there's no PlayerInput component attached, add one
        if (playerInput == null)
        {
            playerInput = gameObject.AddComponent<InputInitialize>();
        }
    }

    private void FixedUpdate()
    {
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, movementInput, ref movementInputSmoothVelocity, 0.1f);
        // Get the current movement input from the player
        movementInput = playerInput.movement.ReadValue<Vector2>();

        // Apply the movement input to the rigidbody's velocity, scaled by the speed
        rigidbody.velocity = smoothedMovementInput * activeMoveSpeed;
        isDashing = playerInput.dash.ReadValue<float>() > 0.5f;

        if (isDashing)
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed * speed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCoolDown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
}

    








