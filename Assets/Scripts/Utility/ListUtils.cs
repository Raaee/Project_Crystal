using System.Collections.Generic;
using UnityEngine;

public static class ListUtils
{
    // Fisher-Yates shuffle algorithm
    public static void Shuffle<T>(this IList<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            (list[randomIndex], list[i]) = (list[i], list[randomIndex]);
        }
    }

    public static T GetRandomElement<T>(this IList<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static List<T> GetRandomElements<T>(this IList<T> list, int count, bool allowDuplicates = true)
    {
        List<T> randomElements = new();
        // Make a copy of the list
        List<T> copy = new(list);

        // Get a random element from copy. If allowDuplicates is false, also remove it from copy
        for (int i = 0; i < count; i++)
        {
            T randomElement = copy.GetRandomElement();
            randomElements.Add(randomElement);
            if (!allowDuplicates)
            {
                copy.Remove(randomElement);
            }
        }
        return randomElements;
    }
}