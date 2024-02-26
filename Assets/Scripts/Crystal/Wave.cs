using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Wave
{
    /// <summary>
    /// The maximum capacity of the wave.
    /// </summary>
    public int capacity;

    /// <summary>
    /// The time distribution mode for spawning the wave.
    /// </summary>
    public TimeDistribution timeDistribution;

    /// <summary>
    /// The list of spawns in the wave.
    /// </summary>
    public List<Spawn> Spawns;

    /// <summary>
    /// Generates the spawns for the wave.
    /// </summary>
    /// <param name="radius">The radius within which the spawns will be generated.</param>
    /// <param name="duration">The duration of the wave.</param>
    /// <param name="probableSpawns">The list of probable objects to spawn.</param>
    public void GenerateSpawns(float radius, float duration, List<ProbableObject> probableSpawns)
    {
        // Clear previous spawns
        Spawns.Clear();

        int i = 0;
        int currentCapacity = 0;

        // Set spawns and positions
        while (currentCapacity < capacity)
        {
            Spawns.Add(new Spawn());
            float angle = Random.Range(0, 2 * Mathf.PI);

            Vector2 position = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
            Spawns[i].position = position;
            var random = ProbableObject.GetRandomProbableObject(probableSpawns, capacity - currentCapacity);
            Spawns[i].spawnObject = random.gameObject;

            // Set time if time distributed by capacity
            if (timeDistribution == TimeDistribution.ByCapacity)
            {
                Spawns[i].timeDelay = duration / capacity * currentCapacity;
            }

            currentCapacity += random.capacity;
            i++;
        }

        // Set spawn times if not distributed by capacity

        // Random will always be a random time in the whole duration
        if (timeDistribution == TimeDistribution.Random)
        {
            foreach (Spawn spawn in Spawns)
            {
                spawn.timeDelay = Random.Range(0, duration);
            }
        }
        // Uniform will the spawns over time based on their index
        int count = Spawns.Count;
        if (timeDistribution == TimeDistribution.Uniform)
        {
            for (int j = 0; j < Spawns.Count; j++)
            {
                Spawns[j].timeDelay = duration / count * j;
            }
        }
    }

    /// <summary>
    /// The time distribution modes for spawning the wave.
    /// </summary>
    [System.Serializable]
    public enum TimeDistribution
    {
        Random,
        ByCapacity,
        Uniform
    }
}