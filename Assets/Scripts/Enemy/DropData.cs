using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropData : MonoBehaviour  {
    public abstract void OnDropInteract(); 
    //Mana , Beserker , Health
    //int manaAmount int healthAmount float berserkerDamageIncrease float berserkerDamageTime
    private GameObject playerGameObject;

    public GameObject getPlayerGameObject() 
    {
    return playerGameObject;
    }
    public void setPlayerGameObject(GameObject newPlayergameObject)
    {
    this.playerGameObject = newPlayergameObject;
    }

}
