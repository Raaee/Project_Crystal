using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected float baseSpeed;
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected float curSpeed;
   
    protected void Start()
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
}
