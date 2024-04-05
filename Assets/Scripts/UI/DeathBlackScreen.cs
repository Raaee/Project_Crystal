using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathBlackScreen : MonoBehaviour
{
    public float fadeDuration = 1.0f; // Adjust as needed
    public Image fadeImage;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        // Initially set the alpha to fully transparent
        fadeImage.color = new Color(0f, 0f, 0f, 0f);
    }

    public void FadeToBlack()
    {
        StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(bool fadeIn)
    {
        float targetAlpha = fadeIn ? 1f : 0f;
        float startAlpha = fadeImage.color.a;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, timer / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, newAlpha);
            timer += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(0f, 0f, 0f, targetAlpha);
    }
}
