using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(RaycastDetector_NC))]
public class RCDetectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        RaycastDetector_NC script = (RaycastDetector_NC)target;
        script.arcRange = EditorGUILayout.Slider("Arc Range", script.arcRange, 0f, 360f);
        DrawDefaultInspector();
    }
}
