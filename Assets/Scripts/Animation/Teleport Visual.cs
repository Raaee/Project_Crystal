using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportVisual : MonoBehaviour
{
    [SerializeField] public SpriteRenderer flashMaterial;
    private TeleportAbility teleportAbility;
    [SerializeField] private Color flashColor = Color.blue;

    [SerializeField] private float shakeDuration = 0.15f;
    [SerializeField] private float shakeMagnitude = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        flashMaterial = GetComponent<SpriteRenderer>();
        teleportAbility = transform.parent.GetComponentInChildren<TeleportAbility>();
        teleportAbility.OnTeleportVisual.AddListener(TriggerTeleport);
        teleportAbility.OnTeleportVisual.AddListener(TriggerScreenShake);
    }

    public void TriggerTeleport()
    {
        StartCoroutine(changecolor());
    }

    public void TriggerScreenShake()
    {
        StartCoroutine(Shake(shakeDuration, shakeMagnitude));
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
