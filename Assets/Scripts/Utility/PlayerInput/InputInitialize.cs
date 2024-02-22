using UnityEngine;
using UnityEngine.InputSystem;

public class InputInitialize : MonoBehaviour
{

    [Header("Player Inputs")]
    public PlayerInputs playerInputs;
    public InputAction movement;
    public InputAction dash;
    public InputAction interact;

    [Header("Attack Inputs")]
    public InputAction basicAttack;
    public InputAction ability1;
    public InputAction ability2;


    private void Awake()
    {
        playerInputs = new PlayerInputs();
    }

    private void onEnable()
    {
        movement = playerInputs.Player.Movement;
        EnableMovement();

        dash = playerInputs.Player.Dash;
        EnableDash();

        interact = playerInputs.Player.Interact;
        EnableInteract();

        basicAttack = playerInputs.Player.BasicAttack;
        EnableBasicAttack();

        ability1 = playerInputs.Player.Ability1;
        EnableAbility1();

        ability2 = playerInputs.Player.Ability2;
        EnableAbility2();
    }

    private void onDisable()
    {
        DisableMovement();
        DisableDash();
        DisableInteract();
        DisableBasicAttack();
        DisableAbility1();
        DisableAbility2();
    }


    public void EnableMovement()
    {
        movement.Enable();
    }
    public void DisableMovement()
    {
        movement.Disable();
    }
    public void EnableDash()
    {
        dash.Enable();
    }
    public void DisableDash()
    {
        dash.Disable();
    }
    public void EnableInteract()
    {
        interact.Enable();
    }
    public void DisableInteract()
    {
        interact.Disable();
    }
    public void EnableBasicAttack()
    {
        basicAttack.Enable();
    }
    public void DisableBasicAttack()
    {
        basicAttack.Disable();
    }
    public void EnableAbility1()
    {
        ability1.Enable();
    }
    public void DisableAbility1()
    {
        ability1.Disable();
    }
    public void EnableAbility2()
    {
        ability2.Enable();
    }
    public void DisableAbility2()
    {
        ability2.Disable();
    }
}
