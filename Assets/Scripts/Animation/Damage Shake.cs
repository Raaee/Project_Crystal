using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageShake : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float shakeDuration = 0.15f;
    [SerializeField] private float shakeMagnitude = 0.4f;
    [SerializeField] private HealthPoints hp;
    
    
    void Start()
    {
      //PlayerManager.Instance.hp.OnHurt.AddListener(TriggerScreenShake);
      hp.OnHurt.AddListener(TriggerScreenShake);
      
    }
    
    

    public void TriggerScreenShake()
    {
        StartCoroutine(Shake(shakeDuration, shakeMagnitude));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-0.5f, 0.5f) * magnitude;
            float y = Random.Range(-0.5f, 0.5f) * magnitude;
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
       //transform.localPosition = originalPos;
    }
}
