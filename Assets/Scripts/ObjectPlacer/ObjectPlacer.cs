using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public static bool isEnabled = false;
    public static GameObject objectToPlace;
    public static GameObject targetObject;
    public static string tagName = "";
    public static string prefixName = "object_";
    public static Vector3 objectOffset = new Vector3();
}
