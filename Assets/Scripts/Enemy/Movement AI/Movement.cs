using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/* 
  <summary> 
  - Explain what the script is doing

        Movement is an abstract class which sets up the Enemy's speed and methods of movement. SetSpeed() changes the curSpeed variable.
    MoveTowardsTarget() and MoveAwayFromTarget() take in a target's transform to move the Enemy to or away from that target. The collision
    methods set the curSpeed to zero and revert it to baseSpeed on exit.

  - Purpose for the script

        This script sets up the basic movement elements for the Enemy GameObject, keeping track of an Enemy's base speed and what speed it has
    at any current moment during gameplay. The script also allows for the speed to be set to a specific value and for the Enemy to move to or
    away from another GameObject's position, notably the Crystal or Player. Collision methods stop the Enemy from shuffling when in contact with
    another GameObject.
  </summary>
*/

public abstract class Movement : MonoBehaviour
{
    // Serialized Speed Variables
    [SerializeField] protected float baseSpeed;
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected float curSpeed;
   
    public virtual void Start()
    {
        curSpeed = baseSpeed;
    }

    // SetSpeed() takes a float argument, 'amount', which curSpeed is set to and then sets curSpeed back to baseSpeeda after a duration.
    public void SetSpeed(float amount)
    {
        this.curSpeed = amount;
        //After duration of speed amp/nerf is over, Ienumerators
        this.curSpeed = baseSpeed;
    }

    // MoveTowardsTarget() takes a Transform argument, 'target' (this is set on the EnemyAI script).
    // A Vector3 called 'direction' calculates where the target is relative to Enemy and then Enemy Translates with that Vector3.
    public void MoveTowardsTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * curSpeed * Time.deltaTime);
    }

    // MoveAwayFromTarget() works the same as MoveTowardsTarget(), just with a negative direction Vector3.
    public void MoveAwayFromTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(-direction * curSpeed * Time.deltaTime);
    }
}
