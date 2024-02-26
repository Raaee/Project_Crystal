using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
/// <summary>
/// Represents an object that can be objected with a certain probability and capacity.
/// </summary>
public class ProbableObject
{
    public GameObject gameObject;

    /// <summary>
    /// The capacity of the probable object. This can be used to represent the difficulty or cost of the object.
    /// </summary>
    public int capacity;
    public float probability;

    /// <summary>
    /// Gets a random probable object from the given list of probable object, based on their capacity and probability.
    /// </summary>
    /// <param name="probableObjects">The list of probable objects to choose from.</param>
    /// <param name="remainingCapacity">The remaining capacity.</param>
    /// <returns>A random probable object from the list, or null if no suitable object is found.</returns>
    public static ProbableObject GetRandomProbableObject(List<ProbableObject> probableObjects, int remainingCapacity = int.MaxValue)
    {
        probableObjects = probableObjects.FindAll(probableObject => probableObject.capacity <= remainingCapacity);

        float totalProbability = 0;
        foreach (ProbableObject probableObject in probableObjects)
        {
            totalProbability += probableObject.probability;
        }

        float randomValue = Random.Range(0, totalProbability);
        float currentProbability = 0;

        foreach (ProbableObject probableObject in probableObjects)
        {
            currentProbability += probableObject.probability;
            if (randomValue < currentProbability && probableObject.capacity <= remainingCapacity)
            {
                return probableObject;
            }
        }

        return null;
    }
}