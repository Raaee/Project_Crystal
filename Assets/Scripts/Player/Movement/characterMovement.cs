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
    }
    private void FixedUpdate()
    {
        // Get the current movement input from the player
        _movementInput = _playerInput.movement.ReadValue<Vector2>();

        // Apply the movement input to the rigidbody's velocity, scaled by the speed
        _rigidbody.velocity = _movementInput * _speed;
    }

    


}








