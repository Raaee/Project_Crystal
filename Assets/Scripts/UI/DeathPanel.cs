using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathPanelTimer : MonoBehaviour
{
    public float countdownDuration = 5f; // Adjust as needed
    public TextMeshProUGUI countdownText;
    private float countdown;

    void Start()
    {
        countdown = countdownDuration;
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }

    void UpdateTimer()
    {
        countdown -= 1f;
        countdownText.text = countdown.ToString();
        if (countdown <= 0)
        {
            // Respawn player or perform any other relevant action
            // For example: GameManager.Instance.RespawnPlayer();
            // You might want to disable the death panel here too
            gameObject.SetActive(false);
        }
    }
}