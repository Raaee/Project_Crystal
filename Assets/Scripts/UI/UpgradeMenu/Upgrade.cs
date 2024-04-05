using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Upgrade : MonoBehaviour
{
    [System.Serializable]
    public enum UpgradeType
    {
        BasicDamagePercent,
        PierceDamagePercent,
        MaxManaPercent,
        MaxHealthPercent,
        AbilityCooldownPercent,
    }

    public UpgradeType upgradeType;
    [HideInInspector] public float upgradeValue;
    public int minValuePercent;
    public int maxValuePercent;
    public Image cardBackground;
    public TMP_Text upgradeDescription;

    public void Start()
    {
        // Set the upgrade description text
        upgradeValue = Random.Range(minValuePercent, maxValuePercent + 1) / 100f;
        upgradeDescription.text = GetUpgradeDescription();
        cardBackground.color = UpgradeMenu.instance.defaultColor;
    }

    public void SelectCard()
    {
        // Set the card background color to the selected color
        cardBackground.color = UpgradeMenu.instance.selectedColor;
        UpgradeMenu.instance.SelectCard(this);
    }

    public string GetUpgradeDescription()
    {
        string green = "<color=\"green\">";
        string yellow = "<color=\"yellow\">";
        string white = "<color=\"white\">";
        switch (upgradeType)
        {
            case UpgradeType.BasicDamagePercent:
                return $"{white}Increase {green}Basic Attack {white}(M1) Damage by {yellow}{(int)(upgradeValue * 100)}%";
            case UpgradeType.PierceDamagePercent:
                return $"{white}Increase {green}Pierce Attack {white}(Q) Damage by {yellow}{(int)(upgradeValue * 100)}%";
            case UpgradeType.MaxManaPercent:
                return $"{white}Increase Max {green}Mana {white}by {yellow}{(int)(upgradeValue * 100)}%";
            case UpgradeType.MaxHealthPercent:
                return $"{white}Increase Max {green}Health {white}by {yellow}{(int)(upgradeValue * 100)}%";
            case UpgradeType.AbilityCooldownPercent:
                return $"{white}Decrease {green}All Ability {white}Cooldowns by {yellow}{(int)(upgradeValue * 100)}%";
            default:
                return $"{white}Unknown";
        }
    }

    public void ApplyUpgrade()
    {
        switch (upgradeType)
        {
            case UpgradeType.BasicDamagePercent:
                BuffManager.instance.IncreaseMaxBasicAttackDamage(upgradeValue);
                break;
            case UpgradeType.PierceDamagePercent:
                BuffManager.instance.IncreaseMaxPierceShotDamage(upgradeValue);
                break;
            case UpgradeType.MaxManaPercent:
                BuffManager.instance.IncreaseMaxMana(upgradeValue);
                BuffManager.instance.AddMana(Mathf.RoundToInt(upgradeValue * 100));
                break;
            case UpgradeType.MaxHealthPercent:
                BuffManager.instance.IncreaseMaxHealth(upgradeValue);
                BuffManager.instance.AddHealth(Mathf.RoundToInt(upgradeValue * 100));
                break;
            case UpgradeType.AbilityCooldownPercent:
                BuffManager.instance.ReduceAllAbilityCooldowns(upgradeValue);
                break;
        }
    }
}