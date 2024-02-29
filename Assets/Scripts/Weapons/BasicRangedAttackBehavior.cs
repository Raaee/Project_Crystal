using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BasicRangedAttackBehavior : MonoBehaviour
{
    [SerializeField] private float rangedAttackSpeed = 15f;
    [SerializeField] private float destroyTime = 3f;
    private Rigidbody2D rigidBody;
    private PlayerMovement playerMovement;
    

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
       
        SetStraightVelocity();
        // This is where you would connect ab object pooler
    }

    private void SetStraightVelocity()
    {
        rigidBody.velocity = transform.right * rangedAttackSpeed;
    }

   
}
