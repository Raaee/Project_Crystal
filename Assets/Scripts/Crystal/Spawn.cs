using UnityEngine;

/// <summary>
/// Represents a spawn point for a game object.
/// </summary>
[System.Serializable]
public class Spawn
{
    /// <summary>
    /// The object to spawn.
    /// </summary>
    [Tooltip("The object to spawn.")]
    public GameObject spawnObject;

    /// <summary>
    /// The position of the spawn point.
    /// </summary>
    [Tooltip("The position of the spawn point.")]
    public Vector2 position;

    /// <summary>
    /// The time after the start of the wave to spawn the object.
    /// </summary>
    [Tooltip("The time after the start of the wave to spawn the object.")]
    public float timeDelay;
}