using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(menuName = "character data")]

public class CharacterDataSO : ScriptableObject
{
    public GameObject characterPrefab;
    public string characterName;
    public string characterDescription;
    
    [Header("Stats")]
    public int health;
    public int mana;
    public int moveSpeed;

    [Header("Basic Attack")]
    public int basicAttackDamage;
    public float basicAttackCooldown;
    public int basicAttackManaCost;

    [Header("Pierce Attack")]
    public int pierceAttackDamage;
    public float pierceAttackCooldown;
    public int pierceManaCost;
    public int pierceAmount;

    [Header("Teleport")]
    public float teleportDistance;
    public float teleportCooldown;
    public float teleportManaCost;

    [Header("Sprites")]
    public Sprite characterSprite;
    public Sprite basicAttackIcon;
    public Sprite pierceAttackIcon;
    public AnimationClip characterWalkAnimation;

}
