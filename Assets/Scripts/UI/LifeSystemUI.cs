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
    private int currentLives = 3;

    private void Start() {
        lifeSystem.OnRemoveLife.AddListener(UpdateLives);
        ResetLives();
    }

    [ProButton]
    public void ResetLives() {
        currentLives = lifeSystem.MaxLives - 1;
        foreach (Image life in livesImages) {
            life.color = Color.white;
        }
    }
    [ProButton]
    public void UpdateLives() {
        RemoveLife(shatterColor);
    }
    public void RemoveLife(Color32 newColor) {
        if (currentLives < 0)
            return;

        livesImages[currentLives].color = newColor;
        currentLives--;
    }

}
