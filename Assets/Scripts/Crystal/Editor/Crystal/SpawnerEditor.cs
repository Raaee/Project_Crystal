using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    SerializedProperty radiusProperty;

    void OnEnable()
    {
        // Setup the SerializedProperties.
        radiusProperty = serializedObject.FindProperty("radius");
    }

    public override void OnInspectorGUI()
    {
        // Start working with the SerializedObject.
        serializedObject.Update();

        EditorGUI.BeginChangeCheck(); // Start change check here

        // Custom UI for the radius to control its placement
        EditorGUILayout.PropertyField(radiusProperty, new GUIContent("Radius"));

        // Check if any property was changed
        if (EditorGUI.EndChangeCheck())
        {
            // If the radius has changed, find and update all ScaleBySpawnerRadius components
            ScaleBySpawnerRadius[] allScaleScripts = FindObjectsOfType<ScaleBySpawnerRadius>();
            foreach (ScaleBySpawnerRadius scaleScript in allScaleScripts)
            {
                if (scaleScript.spawner == (Spawner)target) // Check if it's the spawner we're editing
                {
                    float scale = radiusProperty.floatValue * 2; // Use the serialized property value
                    scaleScript.transform.localScale = new Vector3(scale, scale, scale);
                    EditorUtility.SetDirty(scaleScript.transform); // Mark the transform as dirty to ensure the change is saved
                }
            }
        }

        // Draw the rest of the properties, excluding the radius since it's already drawn
        DrawPropertiesExcluding(serializedObject, "m_Script", "radius");

        // Apply changes to all serializedProperties - including custom drawn ones
        serializedObject.ApplyModifiedProperties();

        // Add a button to regenerate spawns
        if (GUILayout.Button("Regenerate Spawns"))
        {
            Spawner spawner = (Spawner)target;
            // Call a method on the Spawner script to regenerate spawns
            spawner.GenerateSpawns();
        }
    }
}
