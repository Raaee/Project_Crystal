using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected int cooldown;
    [SerializeField] protected int manaCost;
    protected Actions actions;
    



}
