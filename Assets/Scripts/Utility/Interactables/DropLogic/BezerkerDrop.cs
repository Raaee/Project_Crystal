using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BezerkerCubeDrop : DropData
{    
    [SerializeField] public int berserkerDamageMultplyer = 2;
    [SerializeField] public float berserkerDamageTime = 5f;
    [SerializeField] public bool testIsBezerker = false;

    public UnityEvent OnBezerker;
    public UnityEvent StopBezerker;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        //bezerkerTag.gameObject.SetActive(true);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void OnDropInteract()
    {
        OnBezerker.Invoke();
        ApplyBezerkerBuff();
        spriteRenderer.enabled = false;
    }

    private IEnumerator RemoveBerzerker(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Revert buff modifiers
        BuffManager.instance.RemoveBasicAttckDamege();
        BuffManager.instance.RemovePiercesDamage();
        StopBezerker.Invoke();
        this.gameObject.SetActive(false);
    }

    public void ApplyBezerkerBuff()
    {
        BuffManager.instance.MultiplyBasicAttackDamage(berserkerDamageMultplyer);
        BuffManager.instance.MultiplyPierceDamage(berserkerDamageMultplyer);

        Debug.Log("Increasing damage by " + berserkerDamageMultplyer + " for " + berserkerDamageTime + " seconds.");

      //  Debug.Log(StartCoroutine(RemoveBerzerker(berserkerDamageTime)));
        StartCoroutine(RemoveBerzerker(berserkerDamageTime));
    }
}