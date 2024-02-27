using UnityEngine;
using UnityEditor;

/// <summary>
/// Custom editor for the Spawner component.
/// </summary>
[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Spawner spawner = (Spawner)target;
        if (GUILayout.Button("Regenerate Spawns"))
        {
            spawner.GenerateSpawns();
        }
    }
}