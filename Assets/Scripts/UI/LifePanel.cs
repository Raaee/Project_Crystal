using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private Canvas panelCanvas;
    [SerializeField] private Color lifeColor;
    protected CanvasGroup canvasGroup;



    void Start()
    {
        panelCanvas.worldCamera = FindFirstObjectByType<Camera>();
        lifeText.color = lifeColor;
        lifeText.text = "Curruption has consumed you...";
        // Get the CanvasGroup component from the DeathPanel
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public IEnumerator _SceneSwitchDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(panelCanvas);
    }
    public void RestartGame()
    {
        
        SceneManager.LoadScene(1);
        StartCoroutine(_SceneSwitchDelay(2.5f));
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        StartCoroutine(_SceneSwitchDelay(1f));
    }
    


}
