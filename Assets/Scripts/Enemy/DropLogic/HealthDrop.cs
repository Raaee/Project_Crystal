using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : DropData

{
    
    public int healthAmount;
    private void Start()
    {
    OnDropInteract();
    }
   public override void OnDropInteract()
   {
    Debug.Log("Giving the player healthAmount" + healthAmount);

   }

}
