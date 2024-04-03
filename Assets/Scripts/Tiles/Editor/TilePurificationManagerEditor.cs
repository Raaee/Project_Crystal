using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TilePurificationManager))]
public class TilePurificationManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TilePurificationManager myScript = (TilePurificationManager)target;
        if(GUILayout.Button("Purify All Tiles"))
        {
            myScript.PurifyAllTiles();
        }
        if (GUILayout.Button("Corrupt All Tiles")) {
            myScript.CorruptAllTiles();
        }
    }
}