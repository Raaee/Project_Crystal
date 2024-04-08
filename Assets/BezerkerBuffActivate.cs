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

    //Initialize the basicAnimatorberzerker, piercesAnimatorberzerker for the animation and set all animation to deactivated
    private void Start()
    {
        basicAnimatorberzerker = PlayerManager.Instance.rangedBA.GetBasicAttackPrefab().GetComponentInChildren<Animator>();
        piercesAnimatorberzerker = PlayerManager.Instance.pierceShot.GetPiercesAttackPrefab().GetComponentInChildren<Animator>();
        DisActivateBerzerkAnimation();
    }

    //This will activate the berzeker UI and Animation, and Activate the ApplyBezerkerBuff
    public void ActivatAbilty()
    {
        OnBezerker.Invoke();
        ApplyBezerkerBuff();
        ActivateBerzerkAnimation();
    }

    // Will wait for the duration of berserkerDamageTime and remove all buff multiplayers and Stop the berker UI and Animation
    private IEnumerator RemoveBerzerker(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Revert buff modifiers
        BuffManager.instance.ResetBasicAttckDamege();
        BuffManager.instance.ResetPierceDamage();
        DisActivateBerzerkAnimation();
        StopBezerker.Invoke();
    }

    //ApplyBezerkerBuff will give the dammage multiplyer for the abilities and start the buff timer
    public void ApplyBezerkerBuff()
    {
        BuffManager.instance.MultiplyBasicAttackDamage(berserkerDamageMultplyer);
        BuffManager.instance.MultiplyPierceDamage(berserkerDamageMultplyer);
        StartCoroutine(RemoveBerzerker(berserkerDamageTime));
    }

    //Activate the berzeker animations of basic and pierces attacks
    public void ActivateBerzerkAnimation()
    {
        basicAnimatorberzerker.runtimeAnimatorController = animControllerBasicAttackBerkerz;
        piercesAnimatorberzerker.runtimeAnimatorController = animControllerPierceAttackBerzerk;
    }

    //DisActivate the berzeker animations of basic and pierces attacks
    public void DisActivateBerzerkAnimation()
    {
        basicAnimatorberzerker.runtimeAnimatorController = animControllerBasicAttack;
        piercesAnimatorberzerker.runtimeAnimatorController = animControllerPierceAttack;
    }
}
