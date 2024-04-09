using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathPanelTimer : MonoBehaviour
{
    public float countdownDuration = 5f; // Adjust as needed
    public TextMeshProUGUI countdownText;
    private float countdown;
    private bool isCountdownFinished = false;

    // Reference to the CanvasGroup for fading
    private CanvasGroup canvasGroup;

    void Start()
    {
        countdown = countdownDuration;
        StartTimer();

        // Get the CanvasGroup component from the DeathPanel
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup component not found.");
        }
    }

    public void StartTimer()
    {
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }

    void UpdateTimer()
    {
        if (!isCountdownFinished)
        {
            StartCoroutine(FadeIn());
            countdown -= 1f;
            countdownText.text = countdown.ToString();
            if (countdown <= 0)
            {
                // Fade out the death panel
                StartCoroutine(FadeOut());
                isCountdownFinished=true;
                // Respawn player or perform any other relevant action
                // For example: GameManager.Instance.RespawnPlayer();
                // You might want to disable the death panel here too
                PlayerManager.Instance.Respawn();
                countdownText.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator FadeOut()
    {
        if (canvasGroup != null)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime / 2;
                yield return null;
            }
            canvasGroup.interactable = false;
        }
        else
        {
            Debug.LogError("CanvasGroup component not found.");
        }
    }

    IEnumerator FadeIn()
    {
        if (canvasGroup != null)
        {
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime / 2;
                yield return null;
            }
            canvasGroup.interactable = false;
        }
        else
        {
            Debug.LogError("CanvasGroup component not found.");
        }
    }
}