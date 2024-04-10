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
    private float respawnDelayTime = 1.5f;
    [SerializeField] private Canvas deathPanelCanvas;
    [SerializeField] private TextMeshProUGUI respawnText;
    

    // Reference to the CanvasGroup for fading
    private CanvasGroup canvasGroup;

    private void Start()
    {
        deathPanelCanvas.worldCamera = FindFirstObjectByType<Camera>();
        countdown = countdownDuration;
        respawnText.color = Color.red;
        respawnText.text = "You Died...";
        countdownText.gameObject.SetActive(false);
        StartCoroutine(DelayRespawn());

        // Get the CanvasGroup component from the DeathPanel
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public IEnumerator DelayRespawn()
    {
        
        yield return new WaitForSeconds(respawnDelayTime);
        respawnText.color = Color.white;
        respawnText.text = "Respawn in";
        StartTimer();
    }
    public void StartTimer()
    {
        countdownText.gameObject.SetActive(true);
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }

    void UpdateTimer()
    {
        if (!isCountdownFinished)
        {
            //StartCoroutine(FadeIn());
            countdown -= 1f;
            countdownText.text = countdown.ToString();
            if (countdown <= 0)
            {
                // Fade out the death panel
                //StartCoroutine(FadeOut());
                isCountdownFinished=true;
                // Respawn player or perform any other relevant action
                // For example: GameManager.Instance.RespawnPlayer();
                // You might want to disable the death panel here too
                PlayerManager.Instance.Respawn();
                countdownText.gameObject.SetActive(false);
                Destroy(deathPanelCanvas.gameObject);
            }
        }
    }

 /*   IEnumerator FadeOut()
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
    }*/
}