using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "character data")]

public class CharacterDataSO : ScriptableObject
{
    public GameObject characterPreFab;
    public Sprite characterSprite;
    public string characterName;
    public string characterDescription;



}
