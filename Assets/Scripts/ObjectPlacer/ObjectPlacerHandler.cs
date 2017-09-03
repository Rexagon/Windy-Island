using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameObject))]
public class ObjectPlacerHandler : Editor
{
    private void OnSceneGUI()
    {
        if (ObjectPlacer.isEnabled)
        {
            Handles.BeginGUI();

            GUILayout.Label("Placing objects");

            Handles.EndGUI();

            if (ObjectPlacer.isEnabled)
            {
                Event e = Event.current;
                int controlID = GUIUtility.GetControlID(FocusType.Passive);

                switch (e.GetTypeForControl(controlID))
                {
                    case EventType.MouseDown:
                        GUIUtility.hotControl = controlID;

                        if (e.button == 0)
                        {
                            DropObjects();
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }

    private void DropObjects()
    {
        if (!ObjectPlacer.objectToPlace)
        {
            Debug.LogError("Object to place wasn't specified");
        }

        if (!ObjectPlacer.targetObject)
        {
            Debug.LogError("Target object wasn't specified");
            return;
        }
        
        // see if this ray hit something
        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

        RaycastHit hit;
        if (ObjectPlacer.targetObject.GetComponent<Collider>().Raycast(ray, out hit, 1000.0f))
        {
            GameObject placedObject = Instantiate(ObjectPlacer.objectToPlace, hit.transform);

            placedObject.tag = ObjectPlacer.tagName;
            placedObject.name = ObjectPlacer.prefixName + GameObject.FindGameObjectsWithTag(placedObject.tag).Length;

            placedObject.transform.up = hit.normal;
            placedObject.transform.position = hit.point + ObjectPlacer.objectOffset;

            Event.current.Use();

            Undo.RegisterCreatedObjectUndo(placedObject, "Create object");
        }
    }
}
