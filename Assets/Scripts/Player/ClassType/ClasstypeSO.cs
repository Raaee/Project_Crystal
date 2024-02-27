using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Classtype")]

public class ClasstypeSO : ScriptableObject
{
    public const int MAX_HEALTH = 100;
    public const int MAX_MANA = 100;
    public const int MAX_SPEED = 0;
    public Sprite classSprite;
}