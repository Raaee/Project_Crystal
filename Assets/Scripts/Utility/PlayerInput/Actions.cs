using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Actions : MonoBehaviour
{
    
   private InputInitialize input;
   public UnityEvent OnMovement;
   public UnityEvent OnDash;
   public UnityEvent OnInteract;
   public UnityEvent OnBasicAttack;
   public UnityEvent OnAbility1;
   public UnityEvent OnAbility2;


   private void Awake()
   {
    input = GetComponent<InputInitialize>();
   }


}
