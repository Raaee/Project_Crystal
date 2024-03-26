using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(menuName = "character data")]

public class CharacterDataSO : ScriptableObject
{
    public GameObject characterPreFab;
    public Sprite characterSprite;
    public string characterName;
    public string characterDescription;
    public int health;
    public int mana;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI manaText;

    void Start()
    {
        // Randomly assign health and mana values for the mage and the tank
        if (characterName == "Mage")
        {
            health = Random.Range(80, 120); // Example health range for mage
            mana = Random.Range(150, 200); // Example mana range for mage
        }
        else if (characterName == "Tank")
        {
            health = Random.Range(150, 200); // Example health range for tank
            mana = Random.Range(50, 100); // Example mana range for tank
        }

        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();
        }
        if (manaText != null)
        {
            manaText.text = "Mana: " + mana.ToString();
        }
    }
        



}
