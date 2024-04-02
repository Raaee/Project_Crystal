using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropChosenPlayer : MonoBehaviour
{
    [SerializeField] private Transform spawnLocation;
    private CharacterDataSO chosenPlayer;
    [SerializeField] private CharacterDataSO debugCharacterSO;


    private void Start()
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
      
        GameObject player = Instantiate(chosenPlayer.characterPreFab, spawnLocation.position, Quaternion.identity);
        Debug.Log("spawning player", player);
    }

    private void TryGetChosenPlayer()
    {
        if(ChosenPlayerData.Instance)
           chosenPlayer = ChosenPlayerData.Instance.getChosenPlayer();
    }
}
