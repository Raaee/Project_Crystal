using System;
using System.Collections;
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
    

    private void Awake()
    {
        rigidbody ??= GetComponent<Rigidbody2D>();
        playerInput = GetComponent<InputInitialize>();
        actions = GetComponent<Actions>();
        activeMoveSpeed = speed;
        actions.OnDash.AddListener(Dashing);
       
        
        

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


        if (isDashing)
        {
            StartCoroutine(IsDashing());
        }
        /*if (isDashing)
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
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
                isDashing = false;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }*/
    }
    [Header("Dash Settings")]

    private float activeMoveSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] public float dashLength = 0.5f, dashCoolDown = 1f;
    private float dashCounter;
    private float dashCoolCounter;
    private Actions actions;
    private bool isDashing;
   
    public void Dashing()
    {
        isDashing = true;
        
    }

    private IEnumerator IsDashing()
    {
       
        rigidbody.velocity = new Vector2(movementInput.x * dashSpeed, movementInput.y * dashSpeed);
        yield return new WaitForSeconds(dashLength);
        isDashing = false;

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCoolDown;
                isDashing = false;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
        


    }
}

    








