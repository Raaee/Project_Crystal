using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalVFX : MonoBehaviour {

    [Header("VFX")]
    [SerializeField] private GameObject corruptParticleEffect;
    [SerializeField] private GameObject purifiedParticleEffect;
    [SerializeField] private GameObject purifiedAreaLight;
    [SerializeField] private GameObject crystalVisual;
    [SerializeField] private GameObject crystalShadowVisual;
    [SerializeField] private GameObject crystalRadius;

    [Header("Corrupt Visual")]
    [SerializeField] private Sprite corruptedSprite;
    [SerializeField] private Sprite corruptedShadowSprite;
    [SerializeField] private Color32 shatteredColor;
    
    [Header("Purified Visual")]
    [SerializeField] private Sprite purifiedSprite;
    [SerializeField] private Sprite purifiedShadowSprite;
    private SpriteRenderer crystSR;
    private SpriteRenderer shadowSR;

    [Header("Bobbing Settings")]
    [SerializeField] private float bobbingSpeed = 1f; // Speed of the bobbing motion
    [SerializeField] private float bobbingHeight = 0.2f; // Height of the bobbing motion

    private Vector3 originalPosition;

    private void Start() {
        crystSR = crystalVisual.GetComponent<SpriteRenderer>();
        shadowSR = crystalShadowVisual.GetComponent<SpriteRenderer>();
        ActivateCorruptedParticles();
        CorruptSprite();
        DisactivateRadius();
        originalPosition = transform.position;
        StartCoroutine(BobbingCoroutine());
        crystSR.color = Color.white;
    }
    private IEnumerator BobbingCoroutine() {
        while (true) {
            float newY = originalPosition.y + Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            yield return null;
        }
    }
    public void UpdateOriginalYPos(float yPos) {
        originalPosition.y = yPos;
    }
    public void ActivatePurifiedParticles() {
        corruptParticleEffect.SetActive(false);
        purifiedParticleEffect.SetActive(true);
        purifiedAreaLight.SetActive(true);
    }
    public void ActivateCorruptedParticles() {
        purifiedAreaLight.SetActive(false);
        purifiedParticleEffect.SetActive(false);
        corruptParticleEffect.SetActive(true);
    }
    public void PurifySprite() {
        crystSR.sprite = purifiedSprite;
        shadowSR.sprite = purifiedShadowSprite;
    }
    public void CorruptSprite() {
        crystSR.sprite = corruptedSprite;
        shadowSR.sprite = corruptedShadowSprite;
    }
    public void ActivateRadius() {
        crystalRadius.SetActive(true);
    }
    public void DisactivateRadius() {
        crystalRadius.SetActive(false);
    }
    public void ShatterVisual() {
        Debug.Log("visual");

        crystSR.color = shatteredColor;
    }
}
 

