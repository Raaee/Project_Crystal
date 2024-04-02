using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenPlayerData : MonoBehaviour
{
   private CharacterDataSO chosenPlayer;

   public static ChosenPlayerData Instance;
   private void Awake(){
   if (Instance != null){
    Debug.LogError("More than one chosen player data in scene");
    Destroy(this.gameObject);
    return;
   } 
   Instance = this;
   DontDestroyOnLoad(this.gameObject);

   }

   public void setChosenPlayer(CharacterDataSO chosenPlayer)
   {
    this.chosenPlayer = chosenPlayer;
   }

   public CharacterDataSO getChosenPlayer(){
    return chosenPlayer;
   }

   
}
