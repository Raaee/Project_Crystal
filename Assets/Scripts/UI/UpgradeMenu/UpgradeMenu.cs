using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    // Singleton pattern
    public static UpgradeMenu instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        gameObject.SetActive(false);
    }

    public Transform cardParent;
    public Button confirmButton;
    public List<GameObject> possibleCards;

    public Color selectedColor = Color.green;
    public Color defaultColor = Color.white;
    private Upgrade selectedUpgrade;

    public void SelectCard(Upgrade upgrade)
    {
        selectedUpgrade = upgrade;
        foreach (Transform cardTransform in cardParent)
        {
            if (cardTransform != upgrade.transform)
            {
                cardTransform.GetComponent<Upgrade>().cardBackground.color = defaultColor;
            }
            else
            {
                cardTransform.GetComponent<Upgrade>().cardBackground.color = selectedColor;
            }
        }
        confirmButton.interactable = true;
    }

    // whenever the menu is enabled, generate new cards and enable the confirm button
    // Also freeze time
    private void OnEnable()
    {
        GenerateCards();
        confirmButton.interactable = false;
    }

    // whenever the menu is disabled, unfreeze time
    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void GenerateCards(int amount = 3)
    {
        // First, clear the existing cards
        foreach (Transform card in cardParent)
        {
            Destroy(card.gameObject);
        }
        selectedUpgrade = null;

        List<GameObject> shuffledCards = possibleCards.GetRandomElements(amount, false);
        for (int i = 0; i < amount; i++)
        {
            GameObject card = Instantiate(shuffledCards[i], cardParent);
            card.GetComponent<Upgrade>().Start();
        }

    }

    public void ApplyUpgrade()
    {

        selectedUpgrade.ApplyUpgrade();
        // Disable the confirm button after applying the upgrade
        confirmButton.interactable = false;
        // Disable the menu
        gameObject.SetActive(false);
    }
}
