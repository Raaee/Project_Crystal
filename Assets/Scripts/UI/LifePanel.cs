using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private Canvas panelCanvas;
    [SerializeField] private Color lifeColor;
    public List<Image> livesImages;
    protected CanvasGroup canvasGroup;



    void Start()
    {
        panelCanvas.worldCamera = FindFirstObjectByType<Camera>();
        lifeText.color = lifeColor;
        lifeText.text = "Curruption has consumed you...";
        disableLives();
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

    public void disableLives()
    {
        StartCoroutine(_disableLives());
    }

    private IEnumerator _disableLives()
    {
        foreach (Image life in livesImages)
        {
            
            yield return new WaitForSeconds(1.5f);
            life.enabled = false;
        }
    }


}
