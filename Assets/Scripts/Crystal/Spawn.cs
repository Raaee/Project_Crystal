using UnityEngine;

/// <summary>
/// Represents a spawn point for a game object.
/// </summary>
[System.Serializable]
public class Spawn
{
    public GameObject spawnObject;
    public Vector2 position;
    public float timeDelay;
}