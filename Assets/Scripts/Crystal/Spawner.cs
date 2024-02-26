using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    /// <summary>
    /// The duration of each wave in seconds.
    /// </summary>
    public float duration;

    /// <summary>
    /// The radius within which objects can be spawned.
    /// </summary>
    public float radius;

    /// <summary>
    /// The cooldown time between waves in seconds.
    /// </summary>
    public float cooldownTime;

    /// <summary>
    /// The list of objects that can be spawned.
    /// </summary>
    public List<ProbableObject> spawnObjects;

    /// <summary>
    /// The list of waves to be generated.
    /// </summary>
    public List<Wave> waves;

    /// <summary>
    /// Spawns objects for each wave based on the specified radius, duration, and spawn objects.
    /// </summary>
    /// <remarks>
    /// This method iterates through each wave in the list of waves and calls the GenerateSpawns method of the Wave class,
    /// passing in the radius, duration, and spawn objects as parameters.
    /// </remarks>
    public void GenerateSpawns()
    {
        foreach (Wave wave in waves)
        {
            wave.GenerateSpawns(radius, duration, spawnObjects);
        }
    }
}