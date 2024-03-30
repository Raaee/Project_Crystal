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
 
        //getting player game object
        GameObject playerGameObject = getPlayerGameObject();

        //attempting to access the healthpoints scripts from the playerGameObject
        ManaPoints potentialManaPoints = playerGameObject.GetComponent<ManaPoints>();
        
        //if healthpoints isnt null, adds health 
        if (potentialManaPoints != null) {
        potentialManaPoints.AddMana(manaAmount);

        }
        WaitThenDie(); //waiting a couple seconds then dieing, so the audio can fully play sound

    }

}

