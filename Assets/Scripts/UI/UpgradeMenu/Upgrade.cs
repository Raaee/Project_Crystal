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
                return "Increase Normal Attack Damage by " + upgradeValue * 100 + "%";
            case UpgradeType.PierceDamagePercent:
                return "Increase Pierce Attack Damage by " + upgradeValue * 100 + "%";
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
        var basicAttackProjectile = player.GetComponentInChildren<RangedBasicAttack>().projPooler.objectToPool.GetComponentInChildren<Projectile>();
        var pierceAttackProjectile = player.GetComponentInChildren<PiercingShotAbility>().projPooler.objectToPool.GetComponent<PiercingProjectile>();
        var allAbilities = player.GetComponentsInChildren<Ability>();

        switch (upgradeType)
        {
            case UpgradeType.NormalDamagePercent:
                basicAttackProjectile.damage += (int)(basicAttackProjectile.damage * upgradeValue);
                break;
            case UpgradeType.PierceDamagePercent:
                pierceAttackProjectile.damage += (int)(pierceAttackProjectile.damage * upgradeValue);
                break;
            case UpgradeType.MaxManaPercent:
                mana.maxMP += (int)(mana.maxMP * upgradeValue);
                break;
            case UpgradeType.MaxHealthPercent:
                health.maxHP += (int)(health.maxHP * upgradeValue);
                health.currentHP += (int)(health.currentHP * upgradeValue);
                break;
            case UpgradeType.AbilityCooldownPercent:
                foreach (var ability in allAbilities)
                {
                    ability.cooldown -= ability.cooldown * upgradeValue;
                }
                break;
        }
    }
}