using UnityEngine;
using UnityEngine.InputSystem;

public class InputControls : MonoBehaviour    {

    [Header("Player Inputs")]
    public PlayerInputs playerInputs;
    public InputAction movement;
    public InputAction teleport;
    public InputAction interact;

    [Header("Attack Inputs")]
    public InputAction basicAttack;
    public InputAction ability1;
    public InputAction ability2;


    private void Awake()    {
        playerInputs = new PlayerInputs();
    }
    public void OnEnable() {
        movement = playerInputs.Player.Movement;
        teleport = playerInputs.Player.Teleport;       
        interact = playerInputs.Player.Interact;        
        basicAttack = playerInputs.Player.BasicAttack;       
        ability1 = playerInputs.Player.Ability1;       
        ability2 = playerInputs.Player.Ability2;
        EnableControls();
    }
    public void DisableControls() {
        movement.Disable();
        teleport.Disable();
        interact.Disable();
        basicAttack.Disable();
        ability1.Disable();
        ability2.Disable();
    }
    public void EnableControls() {
        movement.Enable();
        teleport.Enable();
        interact.Enable();
        basicAttack.Enable();
        ability1.Enable();
        ability2.Enable();
    }
    
}
