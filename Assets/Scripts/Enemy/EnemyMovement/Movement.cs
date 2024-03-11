using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] private float baseSpeed;
    [SerializeField] private float maxSpeed;
    private float curSpeed;
   
    private void Start()
    {
        curSpeed = baseSpeed;
    }

    private void Update()
    {
        
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
        transform.Translate(-direction * curSpeed * Time.deltaTime);
    }
    //[com.cyborgAssets.inspectorButtonPro.ProButton]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Speed is set to 0
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Speed returns
    }
}
