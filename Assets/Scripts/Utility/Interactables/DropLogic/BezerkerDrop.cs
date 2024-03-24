using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezerkerCubeDrop : DropData

{
    public float berserkerDamageIncrease;
    public float berserkerDamageTime;

     private void Start()
    {

    }
  public override void OnDropInteract()
   {
     Debug.Log("Increasing damage by " + berserkerDamageIncrease + " for " + berserkerDamageTime + " seconds.");
        this.gameObject.SetActive(false);
   }    

}