using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : DropData  {

    [SerializeField] private int healthAmount;

    private void Start()    {
   
    }
    public override void OnDropInteract()    {
        Debug.Log("Giving the player healthAmount" + healthAmount);
        //getting player game object
        GameObject playerGameObject = getPlayerGameObject();

        //attempting to access the healthpoints scripts from the playerGameObject
        HealthPoints potentialHealthPoints = playerGameObject.GetComponent<HealthPoints>();
        Debug.Log("This is the player GO", playerGameObject);
        
        //if healthpoints isnt null, adds health 
        if (potentialHealthPoints != null) {
            Debug.Log("Inside potential health points");
        potentialHealthPoints.AddHealth(healthAmount);

        }
        this.gameObject.SetActive(false);

    }

}
