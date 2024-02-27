using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezerkerDrop : DropData

{
    public float berserkerDamageIncrease;
    public float berserkerDamageTime;
  public override void OnDropInteract()
   {
     Debug.Log("Increasing damage by" + berserkerDamageIncrease + "for" + berserkerDamageTime + "seconds.");

   }    

}
