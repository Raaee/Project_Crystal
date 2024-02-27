using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Actions : MonoBehaviour    {
    
    private InputControls input;

    [HideInInspector] public UnityEvent OnMovement;
    [HideInInspector] public UnityEvent OnTeleport;
    [HideInInspector] public UnityEvent OnInteract;
    [HideInInspector] public UnityEvent OnBasicAttack;
    [HideInInspector] public UnityEvent OnAbility1;
    [HideInInspector] public UnityEvent OnAbility2;

    private void Awake() {
        input = GetComponent<InputControls>();
    }
    private void Update() {

        input.interact.performed += Interact;

        // Abilities
        input.teleport.performed += Teleport;
        input.ability1.performed += Ability1;
        input.ability2.performed += Ability2;
    }
    public void Teleport(InputAction.CallbackContext context) {
        Debug.Log("Teleported");
        OnTeleport.Invoke();
    }
    public void Interact(InputAction.CallbackContext context) {
        Debug.Log("Interact");
        OnInteract.Invoke();
    }
    public void Ability1(InputAction.CallbackContext context) {
        Debug.Log("Ability 1");
        OnAbility1.Invoke();
    }
    public void Ability2(InputAction.CallbackContext context) {
        Debug.Log("Ability 2");
        OnAbility2.Invoke();
    }
}
