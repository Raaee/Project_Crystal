using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Represents a wave of spawns.
/// </summary>
[System.Serializable]
public class Wave
{
    /// <summary>
    /// The duration of the wave.
    /// </summary>
    public float duration;

    /// <summary>
    /// The maximum capacity of the wave.
    /// </summary>
    public int capacity;

    /// <summary>
    /// The list of spawns in the wave.
    /// </summary>
    public List<Spawn> Spawns;

    /// <summary>
    /// Generates the spawns for the wave.
    /// </summary>
    /// <param name="radius">The radius within which the spawns will be generated.</param>
    /// <param name="probableSpawns">The list of probable objects to spawn.</param>
    public void GenerateSpawns(float radius, List<ProbableObject> probableSpawns)
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
            if (random == null) // If no suitable object is found, break the loop
            {
                Spawns.RemoveAt(i);
                break;
            }
            Spawns[i].spawnObject = random.gameObject;
            Spawns[i].timeDelay = duration / capacity * currentCapacity;

            currentCapacity += random.capacity;
            i++;
        }
    }
}