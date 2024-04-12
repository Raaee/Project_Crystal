using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private Canvas panelCanvas;
    protected CanvasGroup canvasGroup;
    public static bool isPaused = false;
    public static PauseMenu instance;
    
    // Start is called before the first frame update

   
    void Start()
    {
        panelCanvas.gameObject.SetActive(false);
        panelCanvas.worldCamera = FindFirstObjectByType<Camera>();

    }

    public IEnumerator _SceneSwitchDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(panelCanvas);
    }
    public void RestartGame()
    {

        RemovePanel();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        StartCoroutine(_SceneSwitchDelay(2.5f));
        
    }

    public void BackToMainMenu()
    {
        
        RemovePanel();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        StartCoroutine(_SceneSwitchDelay(1f));
    }

    public void CheckIfPaused()
    {
        isPaused = !isPaused;
        DoOpenOrClose();
    }

    public void DoOpenOrClose()
    {
        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            UnpauseGame();
        }
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        panelCanvas.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        panelCanvas.gameObject.SetActive(true);
        

    }

    public void RemovePanel()
    {
        isPaused = false;
       
    }

}
