using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
  <summary> 
  - Explain what the script is doing

    1. Start(): the script sets the curSpeed of the GameObject to the baseSpeed (baseSpeed is set on initialization).
    2. SetSpeed(): takes the argument of a float called 'amount' which curSpeed is set to and, after a duration,
       sets curSpeed back to baseSpeed.
    3. MoveTowardsTarget() and MoveAwayFromTarget(): take the argument of a Transfrom called 'target' (should come
       from an external GameObject). A Vector3 called 'direction' calculates where the target is relative to Enemy.
       Enemy then Translates based on that direction (multiplied by curSpeed and Time.deltaTime). Positive direction
       moves towards target while negative moves away.
    4. OnCollisionEnter2D(): curSpeed is set to 0 on collision.
    5. OnCollisionExit2D(): curSpeed reverts back to baseSpeed exiting the collision.

  - Purpose for the script

        This script sets up the basic movement elements for the Enemy GameObject, keeping track of a certain Enemy's
    base speed and what speed it has at any current moment during gameplay:
    - SetSpeed() augments current speed in situations where the enemy is slowed down or gains a boost.
    - MoveTowardsTarget() and MoveAwayFromTarget() move the Enemy to or from another GameObject's position.
    - The Collision methods stop the Enemy from moving and shuffling around its target on collision.

  - Code change suggestions

    - The maxSpeed variable may be unnecessary.
    _ MoveTowardsTarget() and MoveAwayFromTarget() can be turned into one method which takes in a bool that
      determines if direction is positive or negative.
    - Purpose for collision code should be moved to EnemyAI since Ranged Enemies would need different logic.
  </summary>
*/

public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected float baseSpeed;
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected float curSpeed;
   
    private void Start()
    {
        curSpeed = baseSpeed;
    }

    public void SetSpeed(float amount)
    {
        this.curSpeed = amount;
        //After duration of speed amp/nerf is over, Ienumerators
        this.curSpeed = baseSpeed;
    }

    public void MoveTowardsTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * curSpeed * Time.deltaTime);
    }

    public void MoveAwayFromTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(-direction * curSpeed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Speed is set to 0
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Speed returns
    }
}
