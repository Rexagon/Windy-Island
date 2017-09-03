using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObjectPlacerWindow : EditorWindow
{    
    [MenuItem("Window/Object Placer")]
    static void Awake()
    {
        GetWindow<ObjectPlacerWindow>().Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Enabled: ");
        ObjectPlacer.isEnabled = EditorGUILayout.Toggle(ObjectPlacer.isEnabled);

        EditorGUILayout.LabelField("Placing object: ");
        ObjectPlacer.objectToPlace = (GameObject)EditorGUILayout.ObjectField(ObjectPlacer.objectToPlace, typeof(GameObject), true);

        EditorGUILayout.LabelField("Target object: ");
        ObjectPlacer.targetObject = (GameObject)EditorGUILayout.ObjectField(ObjectPlacer.targetObject, typeof(GameObject), true);

        EditorGUILayout.LabelField("Tag name: ");
        ObjectPlacer.tagName = EditorGUILayout.TextField(ObjectPlacer.tagName);

        EditorGUILayout.LabelField("Prefix name: ");
        ObjectPlacer.prefixName = EditorGUILayout.TextField(ObjectPlacer.prefixName);

        ObjectPlacer.objectOffset = EditorGUILayout.Vector3Field("Object offset: ", ObjectPlacer.objectOffset);
    }
}
