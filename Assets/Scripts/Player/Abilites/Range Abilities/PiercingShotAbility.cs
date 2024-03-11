using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PiercingShotAbility : Ability
{
    [SerializeField] private GameObject rangedAbility1Prefab;
    [SerializeField] private ObjectPooler projPooler;
    [SerializeField] private AbilityIndicator abilityIndicator;
    [SerializeField] float delayBetweenPresses = 0.25f;
    private Actions actions;
    private InputControl playerInput;
    private bool KeyPress = true;
    private bool pressedFirstTime = false;
    private float lastPressedTime;
   
    //hello
    void Awake()
    {
        actions = GetComponentInParent<Actions>();
        //actions.OnAbility1.AddListener(ConfirmDoublePress);
        //actions.OnAbility1.AddListener(OnEnableAbilityIndicator);
        //actions.OnAbility1.AddListener(ShootIfActive);
        if (actions == null)
        {
            Debug.LogError("Actions not found");
            Debug.Break();
        }
        actions.OnAbility1.AddListener(ShootIfActive);

    }
    public void SpawnProjectile(Vector2 moveDirection)
    {
        GameObject go = projPooler.GetPooledObject();
        go.transform.position = this.transform.position;
       // go.transform.rotation = Quaternion.identity;
        /*go.transform.eulerAngles += new Vector3(0, 0, 180);*/
        PiercingProjectile projectile = go.GetComponent<PiercingProjectile>();
        projectile.SetMoveDirection(moveDirection);
        go.SetActive(true);

    }
    public void ShootIfActive()
    {
        /*if (indicatorIsActive)
        {
            UseAbility();
        }   */
        if(GetCurrentMana() >= manaCost)
            StartCoroutine(UseAbility());
    }
    public override void AbilityUsage()
    {
        
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 direction = (mousePosition - objectPosition).normalized;
        SpawnProjectile(direction);

    }

    public void ConfirmDoublePress() {
        

        if (KeyPress)
        { 
            if (pressedFirstTime) // we've already pressed the button a first time, we check if the 2nd time is fast enough to be considered a double-press
            {
                
                bool isDoublePress = Time.time - lastPressedTime <= delayBetweenPresses;

                if (isDoublePress)
                {
                    Debug.Log("DoublePress");

                    if (isOnCoolDown)
                        return;

                    StartCoroutine(UseAbility());
                    pressedFirstTime = false;
                }
            }
            else // we've not already pressed the button a first time
            {
                pressedFirstTime = true; // we tell this is the first time
            }

            lastPressedTime = Time.time;
        }
        if (pressedFirstTime && Time.time - lastPressedTime > delayBetweenPresses) // we're waiting for a 2nd key press but we've reached the delay, we can't consider it a double press anymore
        {
            // note that by checking first for pressedFirstTime in the condition above, we make the program skip the next part of the condition if it's not true,
            // thus we're avoiding the "heavy computation" (the substraction and comparison) most of the time.
            // we're also making sure we've pressed the key a first time before doing the computation, which avoids doing the computation while lastPressedTime is still uninitialized

            

            pressedFirstTime = false;
        }
    }

    //public void OnEnableAbilityIndicator()
    //{
    //    abilityIndicator.EnableAbilityIndicator();
    //}
}
