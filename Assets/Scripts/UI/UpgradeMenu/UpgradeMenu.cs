using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject cardPrefab;

    public Transform cardParent;
    public Color selectedColor = Color.green;
    public Color defaultColor = Color.white;
    private Transform selectedCard;

    private Dictionary<Transform, Upgrade> cardUpgradeDict = new Dictionary<Transform, Upgrade>();

    public void SelectCard(Transform card)
    {
        selectedCard = card;
        foreach (Transform cardTransform in cardUpgradeDict.Keys)
        {
            if (cardTransform != card)
            {
                cardTransform.GetComponent<Image>().color = defaultColor;
            }
            else
            {
                cardTransform.GetComponent<Image>().color = selectedColor;
            }
        }
    }

    public void GenerateCards(int amount = 3)
    {
        // First, clear the existing cards
        foreach (Transform card in cardParent)
        {
            Destroy(card.gameObject);
        }
        cardUpgradeDict.Clear();
        selectedCard = null;

        // Generate new cards
        for (int i = 0; i < amount; i++)
        {
            GameObject card = Instantiate(cardPrefab, cardParent);

            // Use reflection to get the total number of UpgradeTypes, and select a random one
            int totalUpgrades = System.Enum.GetNames(typeof(Upgrade.UpgradeType)).Length;
            Upgrade upgrade = new()
            {
                upgradeType = (Upgrade.UpgradeType)Random.Range(0, totalUpgrades),
                upgradeValue = Random.Range(0.1f, 0.5f)
            };

            // Configure the card, including setting its button listener
            card.GetComponent<Image>().color = defaultColor;
            card.GetComponent<Button>().onClick.AddListener(() => SelectCard(card.transform));
            card.GetComponentInChildren<TMP_Text>().text = upgrade.GetUpgradeDescription();
            cardUpgradeDict.Add(card.transform, upgrade);
        }
    }

    public void ApplyUpgrade()
    {
        cardUpgradeDict[selectedCard].ApplyUpgrade();
    }
}