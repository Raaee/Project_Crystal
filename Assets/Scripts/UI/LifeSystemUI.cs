using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystemUI : MonoBehaviour
{
    [SerializeField] private LifeSystem lifeSystem;
    [SerializeField] private Color32 shatterColor;
    public List<Image> livesImages;
    
    [SerializeField] private GameObject lifeDonePanel;

    void Awake()
    {
        disabledLives();
    }
    private void Start()
    {
       
        lifeSystem.OnRemoveLife.AddListener(UpdateLives);
        animateLives();
        ResetLives();
    }

    [ProButton]
    public void ResetLives() {
        lifeSystem.CurrentLives = lifeSystem.MaxLives - 1;
        foreach (Image life in livesImages) {
            life.color = Color.white;
        }
    }
    [ProButton]
    public void UpdateLives() {
        RemoveLife(shatterColor);
    }
    public void RemoveLife(Color32 newColor) {
        if (lifeSystem.CurrentLives < 0)
            return;

        livesImages[lifeSystem.CurrentLives].color = newColor;
        lifeSystem.CurrentLives--;
        
        if (lifeSystem.CurrentLives <= -1) {
           // lifeSystem.LifeDone();
            ShowLifeDonePanel();
        }
    }

    private void animateLives()
    {
        StartCoroutine(_animateLives());

    }

    private IEnumerator _animateLives()
    {
        foreach (Image life in livesImages)
        {
            yield return new WaitForSeconds(1f);
            life.enabled = true;
        }
    }

    private void disabledLives()
    {
        foreach (Image life in livesImages)
        {
            life.enabled = false;
        }
    }
    public void ShowLifeDonePanel() {
        // show panel
        // panel should tell the player their lives are done, text = "You're Done." (show lives done)
        // 1 button for "restart" (this will call lifeSystem.LifeDone();)
        // 1 button for "main menu" (this will load main menu scene)
        PlayerManager.Instance.DestoryDeathPanel();
        Instantiate(lifeDonePanel);
    }

}
