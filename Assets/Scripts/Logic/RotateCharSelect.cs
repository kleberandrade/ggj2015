using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Game/RotateCharSelect")]
public class RotateCharSelect : MonoBehaviour 
{
    public float speedRotation = 45.0f;
	
	void Update () 
    {
        transform.Rotate(Vector3.up, speedRotation * Time.deltaTime);
	}
}
