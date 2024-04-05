using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;

public class Spawner : MonoBehaviour
{
    /// <summary>
    /// The radius within which objects can be spawned.
    /// </summary>
    [Tooltip("The radius within which objects can be spawned.")]
    public float radius;

    /// <summary>
    /// The cooldown time between waves in seconds.
    /// </summary>
    [Tooltip("The cooldown time between waves in seconds.")]
    public float cooldownTime;

    /// <summary>
    /// The parent transform for the spawned objects.
    /// </summary>
    /// <remarks>
    /// This is used to keep the hierarchy clean and organized.
    /// </remarks>
    [Tooltip("The parent transform for the spawned objects.")]
    public Transform spawnParent;

    /// <summary>
    /// The text label for the cooldown timer.
    /// </summary>
    [Tooltip("The text label for the cooldown timer.")]
    public TMPro.TextMeshProUGUI cooldownLabel;

    /// <summary>
    /// The list of objects that can be spawned.
    /// </summary>
    [Tooltip("The list of objects that can be spawned.")]
    public List<ProbableObject> spawnObjects;

    /// <summary>
    /// The list of waves to be generated.
    /// </summary>
    [Tooltip("The list of waves to be generated. Can be populated using the Regenerate Spawns button below, given a capacity.")]
    public List<Wave> waves;

    /// <summary>
    /// The list of spawned objects. Used to keep track of the spawned objects for the current wave.
    /// </summary>
    [Tooltip("The list of spawned objects. Used to keep track of the spawned objects for the current wave.")]
    public List<Transform> spawnedObjects;

    /// <summary>
    /// The current state of the spawner.
    /// </summary>
    [Tooltip("The current state of the spawner.")]
    public State state;

    /// <summary>
    /// The current time of the spawner.
    /// Used to track wave and cooldown times.
    /// </summary>
    [Tooltip("The current time of the spawner. Used to track wave and cooldown times.")]
    public float time;

    [HideInInspector] public UnityEvent OnSpawnerStart;
    private bool started = false;
    [HideInInspector] public UnityEvent OnSpawnerComplete;
    private bool completed = false;
    /// <summary>
    /// Spawns objects for each wave based on the specified radius, duration, and spawn objects.
    /// </summary>
    /// <remarks>
    /// This method iterates through each wave in the list of waves and calls the GenerateSpawns method of the Wave class,
    /// passing in the radius, duration, and spawn objects as parameters.
    /// </remarks>
    public void GenerateSpawns()
    {
        if (waves == null) return;
        foreach (Wave wave in waves)
        {
            wave.GenerateSpawns(radius, spawnObjects);
        }
    }

    /// <summary>
    /// Spawns an object at the specified position.
    /// Then does any necessary setup for the spawned object.
    /// </summary>
    /// <param name="spawn">The spawn to be used for the object.</param>
    /// <returns>The transform of the spawned object.</returns>
    public Transform Spawn(Spawn spawn)
    {
        var obj = Instantiate(spawn.spawnObject, spawn.position + (Vector2)transform.position, Quaternion.identity, spawnParent);

        // Get the EnemyAI component of the spawned object if it exists
        var enemyAI = obj.GetComponent<EnemyAI>();
        if (enemyAI != null)
        {
            enemyAI.SetCrystalObject(transform);
        }
        return obj.transform;
    }

    public void Start()
    {
        GenerateSpawns();
    }

    /// <summary>
    /// Update loop for the spawner.
    /// </summary>
    /// <remarks>
    /// This method updates the state of the spawner based on the current state and time. It uses a state machine pattern to
    /// handle the spawning, cooldown, and completion of waves.
    /// </remarks>
    public void Update()
    {
        switch (state)
        {
            case State.Idle:
                break;
            case State.Spawning:
                time += Time.deltaTime;
                if (waves.Count == 0)
                {
                    state = State.Complete;
                    time = 0;
                    break;
                }
                else
                {
                    while (waves[0].Spawns.Count != 0 && waves[0].Spawns[0].timeDelay <= time)
                    {
                        var spawn = waves[0].Spawns[0];
                        spawnedObjects.Add(Spawn(spawn));
                        waves[0].Spawns.RemoveAt(0);
                    }

                    // Handle transition to cooldown state if there are no more objects to spawn and all transforms in the spawned list are destroyed
                    // Not counting the children of the spawnParent, as they can possibly be moved to another parent, and that feels like an unncessary constraint
                    if (waves[0].Spawns.Count == 0 && spawnedObjects.TrueForAll(obj => obj == null))
                    {
                        waves.RemoveAt(0);
                        spawnedObjects.Clear(); // Clear destroyed objects from the list
                        if (waves.Count == 0)
                        {
                            state = State.Complete;
                            time = 0;
                            break;
                        }
                        state = State.Cooldown;
                        time = 0;
                        break;
                    }
                }
                break;
            case State.Cooldown:
                if (!started)
                {
                    OnSpawnerStart?.Invoke();
                    started = true;
                }
                time += Time.deltaTime;
                cooldownLabel.text = cooldownTime - time > 0 ? Mathf.CeilToInt(cooldownTime - time).ToString("D") : "";
                if (time >= cooldownTime)
                {
                    state = State.Spawning;
                    time = 0;
                }
                break;
            case State.Complete:
                if (!completed)
                {
                    OnSpawnerComplete?.Invoke();
                    completed = true;
                }
                break;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    /// <summary>
    /// Possible states for the spawner.
    /// <list type="bullet">
    ///     <item>
    ///         <term>Idle</term>
    ///         <description>The spawner has not yet activated.</description>
    ///     </item>
    ///     <item>
    ///         <term>Spawning</term>
    ///         <description>The spawner is currently spawning a wave of objects, or the currently spawned wave is not yet cleared.</description>
    ///     </item>
    ///     <item>
    ///         <term>Cooldown</term>
    ///         <description>The spawner is currently in cooldown between waves. Only occurs if there are waves remaining and the spawned list is empty.</description>
    ///     </item>
    ///     <item>
    ///         <term>Complete</term>
    ///         <description>The spawner has completed all waves and is no longer active.</description>
    ///     </item>
    /// </list>
    /// </summary>
    [System.Serializable]
    public enum State
    {
        Idle,
        Spawning,
        Cooldown,
        Complete
    }
}