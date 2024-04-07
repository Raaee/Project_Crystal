using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BezerkerBuffActivate : MonoBehaviour
{
    [SerializeField] public int berserkerDamageMultplyer = 2;
    [SerializeField] public float berserkerDamageTime = 5f;
    [SerializeField] public bool testIsBezerker = false;

    [HideInInspector] public UnityEvent OnBezerker;
    [HideInInspector] public UnityEvent StopBezerker;

    public void ActivatAbilty()
    {
        OnBezerker.Invoke();
        ApplyBezerkerBuff();
        //WaitToDie(berserkerDamageTime + 2f);
    }

    private IEnumerator RemoveBerzerker(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Revert buff modifiers
        BuffManager.instance.ResetBasicAttckDamege();
        BuffManager.instance.ResetPierceDamage();
        StopBezerker.Invoke();
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
