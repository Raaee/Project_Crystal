using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class AnimationControl : MonoBehaviour   {

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void PlayMovement() {
        animator.Play("Down Walk");
    }
    public void PlayAttack() {
        animator.Play("Attack");
    }

    public void PlayBezerker(){
        animator.Play("berserkAnimation");
    }

}
