using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public float duration;
    public float radius;
    public float cooldownTime;
    public List<ProbableSpawn> spawnObjects;
    public List<Wave> waves;

    public void GenerateSpawns()
    {
        foreach (Wave wave in waves)
        {
            wave.GenerateSpawns(radius, duration, spawnObjects);
        }
    }
}