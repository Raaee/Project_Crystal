using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectUI1 : MonoBehaviour
{
   [SerializeField] private Image characterHolder;
   [SerializeField] private TextMeshProUGUI titleText;
   [SerializeField] private TextMeshProUGUI descriptionText;
   [SerializeField] private TextMeshProUGUI basicAttackText;
   [SerializeField] private TextMeshProUGUI specialAttackText;
   private int currentCharacterIndex = 0;
   public List<CharacterDataSO> characters;


   private void setCharacterDisplay(int characterIndex)
   {
    characterHolder.sprite = characters[characterIndex].characterSprite;
    titleText.text = characters[characterIndex].characterName;
    descriptionText.text = characters[characterIndex].characterDescription;
    basicAttackText.text =  " basic attack " + characters[characterIndex].basicAttackDamage;
    specialAttackText.text = " special attack " + characters[characterIndex].specialAttackDamage;
   }

   private void Start()
   {
    if(characters.Count <= 0)
    {
        Debug.LogError("no character set");
        return;
    }
    setCharacterDisplay(currentCharacterIndex);
   }

   public void increaseIndex(){
    Debug.Log("pressing");
    

    currentCharacterIndex++;
    if (currentCharacterIndex >= characters.Count) {
        currentCharacterIndex = 0; // Wrap around to the beginning
    }
    setCharacterDisplay(currentCharacterIndex);

   }

   public CharacterDataSO getCurrentPlayer(){
    return characters[currentCharacterIndex];  
    }

   public void decreaseIndex(){
    
    currentCharacterIndex--;
    if (currentCharacterIndex < 0) {
        currentCharacterIndex = 1; // Stop at zero
    }
    setCharacterDisplay(currentCharacterIndex);

   }


}
