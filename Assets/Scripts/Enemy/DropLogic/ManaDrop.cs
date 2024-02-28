using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaDrop : DropData
{
    public int manaAmount;
     private void Start()
    {
    OnDropInteract();
    }
      public override void OnDropInteract()
   {
 Debug.Log("Giving the player manaAmount" + manaAmount);

   }


}
