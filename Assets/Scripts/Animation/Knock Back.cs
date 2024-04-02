using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class KnockBack : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float knockBackForce = 10f;
    [SerializeField] private float knockBackTime = 0.1f;
    
    

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
      
    }

    void Update()
    {
        rb.velocity = new Vector3(1,1,0) * knockBackForce;
    }


    public IEnumerator KnockBackRoutine(Vector2 direction)
    {
        //Debug.Log("KnockBackRoutine");
        Debug.Log(direction * knockBackForce + "This is the direction force");
        rb.velocity = direction * knockBackForce;
        yield return new WaitForSeconds(knockBackTime);
        rb.velocity = Vector3.zero;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with" + other.gameObject);
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("KnockBack");
            Vector2 direction = other.transform.position - transform.position;
            direction.Normalize();
           // StartCoroutine(KnockBackRoutine(direction));
        }
    }
    /*public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided with" + other.gameObject);
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("KnockBack");
            Vector2 direction = other.transform.position - transform.position;
            direction.Normalize();
            StartCoroutine(KnockBackRoutine(direction));
        }
    }*/
}
