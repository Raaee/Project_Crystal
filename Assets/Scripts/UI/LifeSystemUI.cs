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

    private void Start() {
        lifeSystem.OnRemoveLife.AddListener(UpdateLives);
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
            lifeSystem.LifeDone();
            ShowLifeDonePanel();
        }
    }
    public void ShowLifeDonePanel() {
        // show panel
    }

}
