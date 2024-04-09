using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VingetteHandler : MonoBehaviour
{
    private PlayerHealthPoints playerHealth;
    private bool lowHealthState = false;

    private const float LOW_HEALTH_TRESHOLD = 0.2f;
    private const float TRANSITION_TIME = 0.5f;
    private const float vignetteMaxAmount = 2f;
    private const float vignetteTarget = 1.75f;
    private const float vignetteEndTarget = 0f;

    private Q_Vignette_Single vignette;
    

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealthPoints>();
        playerHealth.OnHealthChange.AddListener(HandleHealthChange);
        vignette = GetComponent<Q_Vignette_Single>();
    }

    private void HandleHealthChange()
    {
        float healthPointPercentage = (float) playerHealth.GetCurrentHP() / playerHealth.GetMaxHealth();
        bool isInCurrentLowHealth = healthPointPercentage < LOW_HEALTH_TRESHOLD;

        if (lowHealthState != isInCurrentLowHealth)
        {
            if (isInCurrentLowHealth)
            {
                TransitionToVignette();
            }
            else
            {
                Debug.Log("Transitioning from vignette in else statement");
                TransitionFromVignette();
            }
        }

    }

    private IEnumerator FadeVignette( float transitionTime, float targetAmount)
    {
        float currentAmount = vignette.mainScale;
        for (float T = 0.0f; T <= transitionTime; T += Time.deltaTime)
        {
            vignette.mainScale = Mathf.Lerp(currentAmount, targetAmount, T / transitionTime);
            yield return null;
        }
        vignette.mainScale = targetAmount;
    }
    private IEnumerator _TransitionToVignette()
    {
        StartCoroutine(FadeVignette(TRANSITION_TIME, vignetteMaxAmount));
        yield return FadeVignette(TRANSITION_TIME, vignetteTarget);
    }

    public void TransitionToVignette()
    {
        StartCoroutine(_TransitionToVignette());
    }

    public void TransitionFromVignette()
    {
        Debug.Log("Transitioning from vignette");
        StartCoroutine(_TransitionFromVignette());
    }

    private IEnumerator _TransitionFromVignette()
    {
        StartCoroutine(FadeVignette(TRANSITION_TIME, vignetteMaxAmount));
        yield return FadeVignette(TRANSITION_TIME, vignetteEndTarget);
    }
}
