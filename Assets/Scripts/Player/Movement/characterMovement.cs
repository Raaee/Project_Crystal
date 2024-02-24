using UnityEngine;
using UnityEngine.InputSystem;

public class characterMovement : MonoBehaviour
{

    [SerializeField] private float _speed;


    private Rigidbody2D _rigidbody;


    private Vector2 _movementInput;


    private InputInitialize _playerInput;


    private void Awake()
    {

        _rigidbody ??= GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<InputInitialize>();
       
        // If there's no PlayerInput component attached, add one
        if (_playerInput == null)
        {
            _playerInput = gameObject.AddComponent<InputInitialize>();
        }

        // Log a message to the console for debugging purposes
        

        // Subscribe the OnMove method to the "Move" action
        //_playerInput.actions["Move"].performed += OnMove;

    }
    private void FixedUpdate()
    {
        // Set the velocity of the Rigidbody2D, effectively moving the character
        _movementInput = _playerInput.movement.ReadValue<Vector2>();
        _rigidbody.velocity = _movementInput * _speed;

        // Log the current movement input to the console for debugging purposes
        
    }

    


}








