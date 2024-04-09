using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectUI : MonoBehaviour
{
    private int currentCharacterIndex = 0;
    public List<CharacterDataSO> characters;

    [Header("Character")]
    [SerializeField] private Animator characterImage;
    [SerializeField] private Image bigCharacterImage;
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI manaText;
    
    [Header("Basic Attack")]
    [SerializeField] private Image basicAttackIcon;
    [SerializeField] private TextMeshProUGUI basicAttackDamage;
    [SerializeField] private TextMeshProUGUI basicAttackCooldown;

    [Header("Pierce Attack")]
    [SerializeField] private Image pierceAttackIcon;
    [SerializeField] private TextMeshProUGUI pierceAttackDamage;
    [SerializeField] private TextMeshProUGUI pierceAttackCooldown;
    [SerializeField] private TextMeshProUGUI pierceAttackManaCost;

    [Header("Teleport")]
    [SerializeField] private TextMeshProUGUI teleportCooldown;
    [SerializeField] private TextMeshProUGUI teleportManaCost;

    private void setCharacterDisplay(int characterIndex)
    {
       
        characterImage.Play(characters[characterIndex].characterWalkAnimation.name);
        bigCharacterImage.sprite = characters[characterIndex].characterSprite;
        characterNameText.text = characters[characterIndex].characterName;
        descriptionText.text = characters[characterIndex].characterDescription;
        basicAttackIcon.sprite = characters[characterIndex].basicAttackIcon;
        pierceAttackIcon.sprite = characters[characterIndex].pierceAttackIcon;

        // Stats
        healthText.text = "" + characters[characterIndex].health;
        manaText.text = "" + characters[characterIndex].mana;

        basicAttackDamage.text =  "Damage: " + characters[characterIndex].basicAttackDamage;
        basicAttackCooldown.text = "Cooldown: " + characters[characterIndex].basicAttackCooldown;

        pierceAttackDamage.text = "Damage: " + characters[characterIndex].pierceAttackDamage;
        pierceAttackCooldown.text = "Cooldown: " + characters[characterIndex].pierceAttackCooldown;
        pierceAttackManaCost.text = "Mana Cost: " + characters[characterIndex].pierceManaCost;

        teleportCooldown.text = "Cooldown: " + characters[characterIndex].teleportCooldown;
        teleportManaCost.text = "Mana Cost: " + characters[characterIndex].teleportManaCost;
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
    
        currentCharacterIndex++;
        if (currentCharacterIndex >= characters.Count) {
            currentCharacterIndex = 0; // Wrap around to the beginning
        }
        setCharacterDisplay(currentCharacterIndex);

    }

    public CharacterDataSO getCurrentCharacterData()
    {
        return characters[currentCharacterIndex];
    }
    public void decreaseIndex(){
    
        currentCharacterIndex--;
        if (currentCharacterIndex < 0) {
            currentCharacterIndex = (characters.Count-1); // Stop at zero
        }
        setCharacterDisplay(currentCharacterIndex);

    }


}
