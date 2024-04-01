using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVisuals : MonoBehaviour
    
{
    [SerializeField] public Sprite flashMaterial;
    [SerializeField] public SpriteRenderer defaultMaterial;
    private HealthPoints healthPoints;
    
    // Start is called before the first frame update
    
    void Start()
    {

        defaultMaterial = GetComponent<SpriteRenderer>();
        healthPoints = GetComponentInParent<HealthPoints>();
        healthPoints.OnHurt.AddListener(TriggerDamage);
        Debug.Log("I've been hurt!");

    }

    public void TriggerDamage()
    {
            Debug.Log("OnTriggerDamage");
    
            StartCoroutine(changecolor());
                
    }


    public IEnumerator changecolor()

    {
        Debug.Log("changecolor");
        GetComponent<SpriteRenderer>().sprite = flashMaterial;
        yield
        return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = defaultMaterial.sprite;
        yield
        return new WaitForSeconds(1f);

    }
}
