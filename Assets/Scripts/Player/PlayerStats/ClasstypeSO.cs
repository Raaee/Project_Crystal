using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Classtype")]

public class ClasstypeSO : ScriptableObject
{
    public int MAX_HEALTH = 100;
    public int MAX_MANA = 100;
    public int MAX_SPEED = 10;
    public Sprite classSprite;
}
