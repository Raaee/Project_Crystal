using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour   {

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void PlayMovement() {
        animator.Play("Down Walk");
    }
    
}
