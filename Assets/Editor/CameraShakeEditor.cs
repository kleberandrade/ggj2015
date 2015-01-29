using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CameraShake))]
public class CameraShakeEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        CameraShake cameraShake = (CameraShake)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Shake"))
            cameraShake.Shake();       
    }
}
