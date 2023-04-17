using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
[CustomEditor(typeof(RaycastDetector_NC)), CanEditMultipleObjects]
public class RCDetectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        RaycastDetector_NC[] scripts = targets.Cast<RaycastDetector_NC>().ToArray();
        float val = scripts[0].arcRange;
        bool allSame = scripts.CheckAlls(val => val.arcRange);
        val = EditorGUILayout.Slider("Arc Range", val, 0, 360f);
        for (int i = 0; i < scripts.Length; i++)
        {
            scripts[i].arcRange = val; 
        }
        
        DrawDefaultInspector();
    }
}
