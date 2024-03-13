using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Actions : MonoBehaviour {

    private InputControls input;

    [HideInInspector] public UnityEvent OnMovement;
    [HideInInspector] public UnityEvent OnTeleport;
    [HideInInspector] public UnityEvent OnInteract;
    [HideInInspector] public UnityEvent OnBasicAttack;
    [HideInInspector] public UnityEvent OnAbility1;
    [HideInInspector] public UnityEvent OnAbility2;
    [HideInInspector] public UnityEvent OnAbilityConfirm;

    private void Awake() {
        input = GetComponent<InputControls>();
    }
    private void Update() {

        input.interact.performed += Interact;

        // Abilities
        input.basicAttack.performed += BasicAttack;
        input.teleport.performed += Teleport;
        input.ability1.performed += Ability1;
        input.ability2.performed += Ability2;
        input.basicAttack.performed += CornfirmAbility;
    }
    public void Teleport(InputAction.CallbackContext context) {
       // Debug.Log("Input Teleported");
        OnTeleport.Invoke();
    }
    public void Interact(InputAction.CallbackContext context) {
       // Debug.Log("Input Interact");
        OnInteract.Invoke();
    }
    public void BasicAttack(InputAction.CallbackContext context)
    {
        //Debug.Log("Input Basic Attack");
        OnBasicAttack.Invoke();
    }
    public void CornfirmAbility(InputAction.CallbackContext context) {
        OnAbilityConfirm.Invoke();
    }
    public void Ability1(InputAction.CallbackContext context) {
        //Debug.Log("Input Ability 1");
        OnAbility1.Invoke();
    }
    public void Ability2(InputAction.CallbackContext context) {
       // Debug.Log("Input Ability 2");
        OnAbility2.Invoke();
    }
}
