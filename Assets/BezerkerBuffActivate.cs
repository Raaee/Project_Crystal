using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;

public class BezerkerBuffActivate : MonoBehaviour
{
    [SerializeField] public int berserkerDamageMultplyer = 2;
    [SerializeField] public float berserkerDamageTime = 5f;
    [SerializeField] public bool testIsBezerker = false;
    [HideInInspector] public UnityEvent OnBezerker;
    [HideInInspector] public UnityEvent StopBezerker;

    [SerializeField] private RuntimeAnimatorController animControllerBasicAttack;
    [SerializeField] private RuntimeAnimatorController animControllerBasicAttackBerkerz;
    [SerializeField] private RuntimeAnimatorController animControllerPierceAttack;
    [SerializeField] private RuntimeAnimatorController animControllerPierceAttackBerzerk;

    private Animator basicAnimatorberzerker;
    private Animator piercesAnimatorberzerker;

    private void Start()
    {
        basicAnimatorberzerker = PlayerManager.Instance.rangedBA.GetBasicAttackPrefab().GetComponentInChildren<Animator>();
        piercesAnimatorberzerker = PlayerManager.Instance.pierceShot.GetPiercesAttackPrefab().GetComponentInChildren<Animator>();
        DisactivateBerzerkAnimation();
    }

    public void ActivatAbilty()
    {
        OnBezerker.Invoke();
        ApplyBezerkerBuff();
        ActivateBerzerkAnimation();
    }

    private IEnumerator RemoveBerzerker(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Revert buff modifiers
        BuffManager.instance.ResetBasicAttckDamege();
        BuffManager.instance.ResetPierceDamage();
        DisactivateBerzerkAnimation();
        StopBezerker.Invoke();
    }

    public void ApplyBezerkerBuff()
    {
        BuffManager.instance.MultiplyBasicAttackDamage(berserkerDamageMultplyer);
        BuffManager.instance.MultiplyPierceDamage(berserkerDamageMultplyer);
        StartCoroutine(RemoveBerzerker(berserkerDamageTime));
    }

    public void ActivateBerzerkAnimation()
    {
        basicAnimatorberzerker.runtimeAnimatorController = animControllerBasicAttackBerkerz;
        piercesAnimatorberzerker.runtimeAnimatorController = animControllerPierceAttackBerzerk;
    }
    public void DisactivateBerzerkAnimation()
    {
        basicAnimatorberzerker.runtimeAnimatorController = animControllerBasicAttack;
        piercesAnimatorberzerker.runtimeAnimatorController = animControllerPierceAttack;
    }
}
