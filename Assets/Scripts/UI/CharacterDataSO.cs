using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(menuName = "character data")]

public class CharacterDataSO : ScriptableObject
{
    public GameObject characterPrefab;
    public Sprite characterSprite;
    public string characterName;
    public string characterDescription;
    public int health;
    public int mana;
    public int basicAttackDamage;
    public int specialAttackDamage;
    public int pierceAmount;



}
