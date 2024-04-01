using UnityEngine;

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

    public void ApplyUpgrade(Transform player)
    {
        var health = player.GetComponent<PlayerHealthPoints>();
        var mana = player.GetComponent<ManaPoints>();

        switch (upgradeType)
        {
            case UpgradeType.AttackDamagePercent:
                Debug.Log("Damage upgrade not implemented yet");
                break;
            case UpgradeType.AttackPiercePercent:
                Debug.Log("Pierce upgrade not implemented yet");
                break;
            case UpgradeType.MaxManaPercent:
                mana.maxMP += (int)(mana.maxMP * upgradeValue);
                break;
            case UpgradeType.MaxHealthPercent:
                health.maxHP += (int)(health.maxHP * upgradeValue);
                health.currentHP += (int)(health.currentHP * upgradeValue);
                break;
            case UpgradeType.AbilityCooldownPercent:
                Debug.Log("Cooldown upgrade not implemented yet");
                break;
        }
    }
}