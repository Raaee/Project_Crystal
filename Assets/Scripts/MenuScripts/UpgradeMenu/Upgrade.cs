using System.Diagnostics;

[System.Serializable]
public class Upgrade
{
    public enum UpgradeType
    {
        AttackDamagePercent,
        AttackPiercePercent,
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
            case UpgradeType.AttackDamagePercent:
                return "Increase Attack Damage by " + upgradeValue * 100 + "%";
            case UpgradeType.AttackPiercePercent:
                return "Increase Attack Pierce by " + upgradeValue * 100 + "%";
            case UpgradeType.MaxManaPercent:
                return "Increase Max Mana by " + upgradeValue * 100 + "%";
            case UpgradeType.MaxHealthPercent:
                return "Increase Max Health by " + upgradeValue * 100 + "%";
            case UpgradeType.AbilityCooldownPercent:
                return "Decrease Ability Cooldown by " + upgradeValue * 100 + "%";
            default:
                return "Unknown";
        }
    }

    public void ApplyUpgrade()
    {
        Debug.WriteLine(GetUpgradeDescription());
    }
}