using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProbableSpawn
{
    public GameObject spawnObject;
    public int capacity;
    public float probability;

    // Returns a random probable spawn from the list of probableSpawns, based on the probability and capacity of each probableSpawn
    // Starts by filtering out the probableSpawns that have capacity less than or equal to remainingCapacity
    // Then, it generates a random value between 0 and the total probability of the remaining probableSpawns
    // It iterates through the remaining probableSpawns, adding up their probabilities until the random value is less than the current probability
    // Finally, it returns the probableSpawn at the current index
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