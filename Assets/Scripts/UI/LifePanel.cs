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
    public Image corruptedCrystalImage;
    protected CanvasGroup canvasGroup;
    private const float targetAlpha = 0.1411765f;


    void Awake()
    {
        DisableCrystalImage();
    }
    void Start()
    {
        panelCanvas.worldCamera = FindFirstObjectByType<Camera>();
        lifeText.color = lifeColor;
        lifeText.text = "Curruption has consumed you...";
        disableLives();
        // Get the CanvasGroup component from the DeathPanel
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void DisableCrystalImage()
    {
        corruptedCrystalImage.color = new Color(0, 0, 0, 0);
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
            
            yield return new WaitForSeconds(1f);
            life.enabled = false;
        }

        StartCoroutine(FadeIn());

    }

    private IEnumerator FadeIn()
    {
        for (float T = 0.0f; T <= 1.5f; T += Time.deltaTime)
        {

            corruptedCrystalImage.color = new Color(0.4235294f, 0.2627451f, 0.4588236f, Mathf.Lerp(0,targetAlpha,T/ 1f));
            yield return null;
        }
        corruptedCrystalImage.alphaHitTestMinimumThreshold = targetAlpha;
    }


}
