using UnityEditor;
using UnityEngine;

public class DevMode
{
    private const string peteSpittingBars = "Damage is negated.... Goose Mode Activated.";
    private const int RAEUS_DAMAGE = 999999999;

    [MenuItem("Dev Mode/Commit War Crimes")]
    public static void KillAllEnemies()
    {
        Debug.Log("Commiting War Crimes... Approved by Raeus");
        var enemies = GameObject.FindObjectsOfType<EnemyHealthPoints>();
        foreach (EnemyHealthPoints enemyHealth in enemies)
        {
            enemyHealth.RemoveHealth(RAEUS_DAMAGE);
        }

    }
    [MenuItem("Dev Mode/Kill Player")]
    public static void KillPlayer() {
        Debug.Log("YOU DIE");
        PlayerManager.Instance.hp.RemoveHealth(RAEUS_DAMAGE);
    }
    [MenuItem("Dev Mode/Nuke Current Crystal")]
    public static void KillCurrentCrystal() {
        if (!CrystalManager.Instance.GetCurrentCrystal()) {
            Debug.Log("No current crystal");
            return;
        }
        Debug.Log("Nuking Crystal...");
        CrystalManager.Instance.GetCurrentCrystal().GetHP().RemoveHealth(RAEUS_DAMAGE);
    }


    [MenuItem("Dev Mode/Toggle Goose Mode")]
    public static void ToggleInvincibility()
    {

        var player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
        {
            Debug.Log("dont think theres a player in this scene bub");
            return;
        }

        player.GetComponent<PlayerHealthPoints>().ToggleGooseMode();
        Debug.Log(peteSpittingBars);
    }
    [MenuItem("Dev Mode/Purify All Crystals")]
    public static void PurifyAll() {
        Debug.Log("Purifying all crystals...");
        foreach (Crystal crystal in CrystalManager.Instance.crystals) {
            crystal.spawner.state = Spawner.State.Complete;
        }
    }
    [MenuItem("Dev Mode/Purify All Except Boss Crystal")]
    public static void PurifyAllExceptBoss() {
        Debug.Log("Purifying all crystals... Except the boss");
        foreach (Crystal crystal in CrystalManager.Instance.crystals) {
            if (crystal.gameObject.CompareTag("BossCrystal"))
                continue;
            crystal.spawner.state = Spawner.State.Complete;
        }
    }

    [MenuItem("Dev Mode/List All Current Stats")]
    public static void ListAllCurrentStats()
    {
        Debug.Log("Not implemented yet.... sucka ");
    }

   
}