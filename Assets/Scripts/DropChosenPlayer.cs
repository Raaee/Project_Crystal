using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropChosenPlayer : MonoBehaviour
{
    [SerializeField] private Transform spawnLocation;
    public CharacterDataSO chosenPlayer;
    [SerializeField] private CharacterDataSO debugCharacterSO;


    private void Awake()
    {
        SpawnPlayer();
    }
    public void SpawnPlayer()
    {
        TryGetChosenPlayer();
        if (chosenPlayer == null)
        {
            chosenPlayer = debugCharacterSO;
        }
        GameObject player = Instantiate(chosenPlayer.characterPrefab, spawnLocation.position, Quaternion.identity);
        PlayerManager.Instance.SetPlayer(player);
        PlayerManager.Instance.SetSpawnPoint(spawnLocation);


    }

    private void TryGetChosenPlayer()
    {
        if (ChosenPlayerData.Instance)
            chosenPlayer = ChosenPlayerData.Instance.GetChosenPlayer();
    }
}
