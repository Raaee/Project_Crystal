using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Returns a random probable spawn from the list of probableSpawns, based on the probability and capacity of each probableSpawn.
/// </summary>
/// <param name="probableSpawns">The list of probableSpawns to choose from.</param>
/// <param name="remainingCapacity">The remaining capacity to consider when selecting a probable spawn. Defaults to int.MaxValue.</param>
/// <returns>The randomly selected probable spawn.</returns>
[System.Serializable]
public class ProbableSpawn
{
    /// <summary>
    /// The object to be spawned.
    /// </summary>
    public GameObject spawnObject;

    /// <summary>
    /// The maximum capacity of the spawn. More difficult enemies can have a higher capacity to prevent them from being spawned too frequently.
    /// </summary>
    public int capacity;

    /// <summary>
    /// The probability of this spawn being selected.
    /// </summary>
    public float probability;

    /// <summary>
    /// Gets a random ProbableSpawn object from the given list, based on their probabilities and remaining capacity.
    /// </summary>
    /// <param name="probableSpawns">The list of ProbableSpawn objects to choose from.</param>
    /// <param name="remainingCapacity">The remaining capacity for spawning.</param>
    /// <returns>A random ProbableSpawn object, or null if no suitable spawn is found.</returns>
    public static ProbableSpawn GetRandomProbableSpawn(List<ProbableSpawn> probableSpawns, int remainingCapacity = int.MaxValue)
    {
        // filter
        probableSpawns = probableSpawns.FindAll(probableSpawn => probableSpawn.capacity <= remainingCapacity);

        // get total
        float totalProbability = 0;
        foreach (ProbableSpawn probableSpawn in probableSpawns)
        {
            totalProbability += probableSpawn.probability;
        }

        // get random
        float randomValue = Random.Range(0, totalProbability);
        float currentProbability = 0;

        // find index of random
        foreach (ProbableSpawn probableSpawn in probableSpawns)
        {
            currentProbability += probableSpawn.probability;
            if (randomValue < currentProbability && probableSpawn.capacity <= remainingCapacity)
            {
                return probableSpawn;
            }
        }

        return null;
    }
}