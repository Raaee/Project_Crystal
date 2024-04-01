using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class AnimationControl : MonoBehaviour   {

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }

    public void PlayMovement() {
        animator.Play("Down Walk");
    }
    [ProButton]
    public void PlayAttack() {
        animator.Play("Attack");
    }
    
}
