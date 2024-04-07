using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : DropData  {

    [SerializeField] private int healthAmount;

    private void Start()    {

    }
    public override void OnDropInteract()    
    {
        //getting player game object
        GameObject playerGameObject = getPlayerGameObject();

        //attempting to access the healthpoints scripts from the playerGameObject
        HealthPoints potentialHealthPoints = playerGameObject.GetComponent<HealthPoints>();
        
        //if healthpoints isnt null, adds health 
        if (potentialHealthPoints != null) 
        {
            potentialHealthPoints.AddHealth(healthAmount);
        }
        WaitToDie(); //waiting a couple seconds then dieing, so the audio can fully play sound

    }

}
