using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]

abstract class Ability : ScriptableObject
{
    public const int MAX_ABILITY_DAMAGE = 0;
    public const int MAX_BASIC_DAMAGE = 0;
    public const int MAX_AOE_RADIUS = 0;
    public const int BASIC_DASH_RANGE = 0;
    public const int ATTACK_RANGE = 0;
    
}
