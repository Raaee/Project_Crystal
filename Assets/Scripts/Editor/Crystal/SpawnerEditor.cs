using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Spawner spawner = (Spawner)target;
        if (GUILayout.Button("Generate Spawns"))
        {
            spawner.GenerateSpawns();
        }
    }
}