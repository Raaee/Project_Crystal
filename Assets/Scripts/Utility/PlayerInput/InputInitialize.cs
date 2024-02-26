using UnityEngine;
using UnityEngine.InputSystem;

public class InputInitialize : MonoBehaviour    {

    [Header("Player Inputs")]
    public PlayerInputs playerInputs;
    public InputAction movement;
    public InputAction dash;
    public InputAction interact;

    [Header("Attack Inputs")]
    public InputAction basicAttack;
    public InputAction ability1;
    public InputAction ability2;


    private void Awake()    {
        playerInputs = new PlayerInputs();
    }
    private void OnEnable() {
        movement = playerInputs.Player.Movement;
        movement.Enable();

        dash = playerInputs.Player.Dash;
        dash.Enable();

        interact = playerInputs.Player.Interact;
        interact.Enable();

        basicAttack = playerInputs.Player.BasicAttack;
        basicAttack.Enable();

        ability1 = playerInputs.Player.Ability1;
        ability1.Enable();

        ability2 = playerInputs.Player.Ability2;
        ability2.Enable();
    }
    
}
