using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drowning : MonoBehaviour
{
    private PlayerHealthPoints healthPoints;
    [SerializeField] private int drowningDamage = 1;
    [SerializeField] private string colliderTille = "Water";
    [SerializeField] private bool isDrowning = false;
    [SerializeField] private float timeBetweenDamage = 1f;
    [SerializeField] private BoxCollider2D boxCollider2D;
    public UnityEvent OnDrowning;
    public UnityEvent StopDrowning;


    private void Start()
    {
        healthPoints = GetComponent<PlayerHealthPoints>();
        
    }

    // Will remove health from the player health every frame.
    // How fast the player takes damage depends on the variables damageInterval and damageTimer
    public IEnumerator PlayerDrowning()
    { 
        if (isDrowning) {
            OnDrowning.Invoke();
            healthPoints.RemoveHealth(drowningDamage);
            yield return new WaitForSeconds(timeBetweenDamage);
            StartCoroutine(PlayerDrowning());
        }
    }

    // When enter the collider the player will lose a health in a rate decided by healthTakenFromCollider
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(colliderTille)) {
            isDrowning = true;
            StartCoroutine(PlayerDrowning());
        }  
    }

    // When player is not on the collider the damege taken will stop
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(colliderTille)) { 
            isDrowning = false;
            StopDrowning.Invoke();
        }    
    } 
}
