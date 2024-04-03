using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BezerkerCubeDrop : DropData
{    
    [SerializeField] public int berserkerDamageMultplyer = 2;
    [SerializeField] public float berserkerDamageTime = 10;
    [SerializeField] public bool testIsBezerker = false;

    public UnityEvent OnBezerker;
    public UnityEvent StopBezerkerg;




    private void Start()
    {
        //bezerkerTag.gameObject.SetActive(true);
    }

    public override void OnDropInteract()
    {
        BuffManager.instance.MultiplyBasicAttackDamage(berserkerDamageMultplyer);
        BuffManager.instance.MultiplyPierceDamage(berserkerDamageMultplyer);
        OnBezerker.Invoke();

        Debug.Log("Increasing damage by " + berserkerDamageMultplyer + " for " + berserkerDamageTime + " seconds.");
        this.gameObject.SetActive(false);
        //getting player game object
    }

    
}