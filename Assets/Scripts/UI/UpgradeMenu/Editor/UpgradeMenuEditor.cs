using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UpgradeMenu))]
public class UpgradeMenuEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // for other non-serialized fields

        UpgradeMenu upgradeMenu = (UpgradeMenu)target;
        if(GUILayout.Button("Generate Cards"))
        {
            upgradeMenu.GenerateCards(3);
        }
    }
}