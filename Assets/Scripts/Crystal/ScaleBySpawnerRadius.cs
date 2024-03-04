using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBySpawnerRadius : MonoBehaviour
{
    public Spawner spawner;

    public void Update()
    {
        float scale = spawner.radius * 2;
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
