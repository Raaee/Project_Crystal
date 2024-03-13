using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaDrop : DropData
{
    public int manaAmount;
     private void Start()
    {

    }
      public override void OnDropInteract()
   {
 
        Debug.Log("Giving the player manaAmount" + manaAmount);
        //getting player game object
        GameObject playerGameObject = getPlayerGameObject();

        //attempting to access the healthpoints scripts from the playerGameObject
        ManaPoints potentialManaPoints = playerGameObject.GetComponent<ManaPoints>();
        Debug.Log("This is the player GO", playerGameObject);
        
        //if healthpoints isnt null, adds health 
        if (potentialManaPoints != null) {
            Debug.Log("Inside potential mana points");
        potentialManaPoints.AddMana(manaAmount);

        }
    }

   }

