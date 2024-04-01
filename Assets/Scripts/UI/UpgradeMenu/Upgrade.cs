using UnityEngine;

[System.Serializable]
public class Upgrade
{
    public enum UpgradeType
    {
        NormalDamagePercent,
        PierceDamagePercent,
        MaxManaPercent,
        MaxHealthPercent,
        AbilityCooldownPercent,
    }

    public UpgradeType upgradeType;
    public float upgradeValue;

    public string GetUpgradeDescription()
    {
        switch (upgradeType)
        {
            case UpgradeType.NormalDamagePercent:
                return "Increase Normal Attack Damage by " + (int)(upgradeValue * 100) + "%";
            case UpgradeType.PierceDamagePercent:
                return "Increase Pierce Attack Damage by " + (int)(upgradeValue * 100) + "%";
            case UpgradeType.MaxManaPercent:
                return "Increase Max Mana by " + (int)(upgradeValue * 100) + "%";
            case UpgradeType.MaxHealthPercent:
                return "Increase Max Health by " + (int)(upgradeValue * 100) + "%";
            case UpgradeType.AbilityCooldownPercent:
                return "Decrease Ability Cooldown by " + (int)(upgradeValue * 100) + "%";
            default:
                return "Unknown";
        }
    }

    public void ApplyUpgrade()
    {
        switch (upgradeType)
        {
            case UpgradeType.NormalDamagePercent:
                BuffManager.instance.IncreaseMaxBasicAttackDamage(upgradeValue);
                break;
            case UpgradeType.PierceDamagePercent:
                BuffManager.instance.IncreaseMaxPierceShotDamage(upgradeValue);
                break;
            case UpgradeType.MaxManaPercent:
                BuffManager.instance.IncreaseMaxMana(upgradeValue);
                break;
            case UpgradeType.MaxHealthPercent:
                BuffManager.instance.IncreaseMaxHealth(upgradeValue);
                break;
            case UpgradeType.AbilityCooldownPercent:
                BuffManager.instance.ReduceAllAbilityCooldowns(upgradeValue);
                break;
        }
    }
}