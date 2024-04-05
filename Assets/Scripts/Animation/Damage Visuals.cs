using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVisuals : MonoBehaviour
    
{
    [SerializeField] public SpriteRenderer flashMaterial;
    private HealthPoints healthPoints;
    [SerializeField] private Color flashColor = Color.red;
    
    // Start is called before the first frame update
    
    void Start()
    {

        flashMaterial = GetComponent<SpriteRenderer>();
        healthPoints = GetComponentInParent<HealthPoints>();
        healthPoints.OnHurt.AddListener(TriggerDamage);
        

    }

    public void TriggerDamage()
    {
            
    
            StartCoroutine(changecolor());
                
    }


    public IEnumerator changecolor()

    {
        
        flashMaterial.color = flashColor;
        yield
        return new WaitForSeconds(0.1f);
        flashMaterial.color = Color.white;
        yield
        return new WaitForSeconds(0.1f);

    }
}
