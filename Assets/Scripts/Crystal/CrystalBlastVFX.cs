using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBlastVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem blastVFX;
    private float maxRadius = 8f;
    private float maxDonutRadius = 0.35f;
    private bool blastActive = false;

    [Header("Crystal Blast Audio")]
    private AudioSource audioSource;
    [SerializeField] AudioClip crystalBlastClip;

    private void Start() {
        DisactivateVFX();
        var shape = blastVFX.shape;
        shape.donutRadius = maxDonutRadius;
        audioSource = GetComponent<AudioSource>();
    }
    [ProButton]
    public void ActivateVFX() {
        BlastActive(true);
        ResetVFX();
        blastVFX.transform.parent.gameObject.SetActive(true);
        StartCoroutine(BlastIncrease());
        audioSource.PlayOneShot(crystalBlastClip);
    }
    public void DisactivateVFX() {
        blastVFX.transform.parent.gameObject.SetActive(false);
    }
    public void ResetVFX() {
        var shape = blastVFX.shape;
        shape.radius = 0f;
        shape.donutRadius = 0f;
    }
    public IEnumerator BlastIncrease() {
        var shape = blastVFX.shape;

        while (blastActive) {
            shape.radius += 0.1f;
            if (shape.radius >= maxRadius) {
                shape.radius = maxRadius;
            }

            if (shape.radius == maxRadius) {
                blastActive = false;
                yield return new WaitForSeconds(0.2f);
                DisactivateVFX();
            }
            yield return new WaitForSeconds(0.005f);
        }
    }
    public void BlastActive(bool isActive) {
        blastActive = isActive;
    }

}
