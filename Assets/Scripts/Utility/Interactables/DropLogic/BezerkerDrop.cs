using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BezerkerCubeDrop : DropData
{    
    [SerializeField] public float berserkerDamageTime = 5f;
    private BezerkerBuffActivate BezerkerBuffActivate;

    private void Start()
    {
        GameObject bezerkeBezerkerClone = GameObject.FindGameObjectWithTag("BezerkerTag");
        BezerkerBuffActivate = bezerkeBezerkerClone.GetComponent<BezerkerBuffActivate>();
    }
    public override void OnDropInteract()
    {
        Debug.Log("Interacted");
        BezerkerBuffActivate.ActivatAbilty();
        WaitToDie(berserkerDamageTime + 2f);
    }
}