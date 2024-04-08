using UnityEditor;
using UnityEngine;

public class DevMode
{
    private const string peteSpittingBars = "Damage is negated.... Goose Mode Activated.";

    [MenuItem("Dev Mode/Commit War Crimes")]
    public static void KillAllEnemies()
    {
        Debug.Log("Commiting War Crimes... Approved by Raeus");
        int RAEUS_DAMAGE = 999999999;
        var enemies = GameObject.FindObjectsOfType<EnemyHealthPoints>();
        foreach (EnemyHealthPoints enemyHealth in enemies)
        {
            enemyHealth.RemoveHealth(RAEUS_DAMAGE);
        }

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

  

    [MenuItem("Dev Mode/List All Current Stats")]
    public static void ListAllCurrentStats()
    {
        Debug.Log("Not implemented yet.... sucka ");
    }

   
}