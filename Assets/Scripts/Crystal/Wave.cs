using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Wave
{
    public int capacity;
    public TimeDistribution timeDistribution;
    public List<Spawn> Spawns;

    public void GenerateSpawns(float radius, float duration, List<ProbableSpawn> probableSpawns)
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
            var random = ProbableSpawn.GetRandomProbableSpawn(probableSpawns, capacity - currentCapacity);
            Spawns[i].spawnObject = random.spawnObject;

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

    [System.Serializable]
    public enum TimeDistribution
    {
        Random,
        ByCapacity,
        Uniform
    }
}