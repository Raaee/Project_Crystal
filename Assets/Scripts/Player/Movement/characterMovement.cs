using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



/*public class characterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    public Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private PlayerInput _playerInput;
*/

    /*
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 _movement = new Vector2(horizontalInput, verticalInput).normalized;
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = _movement * _speed;
        }

    }*/

    public class characterMovement : MonoBehaviour
{
    // The speed at which the character moves
    [SerializeField]
    private float _speed;

    // The Rigidbody2D component attached to the character, used for physics-based movement
    public Rigidbody2D _rigidbody;

    // The current movement input, a 2D vector representing the direction and magnitude of movement
    private Vector2 _movementInput;

    // The PlayerInput component, used to handle input from the player
    private PlayerInput _playerInput;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Get the Rigidbody2D component attached to the same GameObject
        _rigidbody = GetComponent<Rigidbody2D>();

        // Get the PlayerInput component attached to the same GameObject
        _playerInput = GetComponent<PlayerInput>();

        // If there's no PlayerInput component attached, add one
        if (_playerInput == null)
        {
            _playerInput = gameObject.AddComponent<PlayerInput>();
        }

        // Log a message to the console for debugging purposes
        Debug.Log(" I am working");

        // Subscribe the OnMove method to the "Move" action
        //_playerInput.actions["Move"].performed += OnMove;
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate
    private void FixedUpdate()
    {
        // Set the velocity of the Rigidbody2D, effectively moving the character
        _rigidbody.velocity = _movementInput * _speed;

        // Log the current movement input to the console for debugging purposes
        Debug.Log(_movementInput);
    }

    // Called when the "Move" action is performed
    private void OnMove(InputValue inputValue)
    {
        // Get the value of the input as a Vector2 and store it in _movementInput
        _movementInput = inputValue.Get<Vector2>();

        // Log the current movement input to the console for debugging purposes
        Debug.Log(_movementInput);
    }

    // Called when the script is being destroyed
    private void OnDestroy()
    {
        // Unsubscribe the OnMove method from the "Move" action
        // _playerInput.actions["Move"].performed -= OnMove; 
    }
}


