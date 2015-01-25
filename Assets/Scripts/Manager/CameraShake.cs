using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour 
{
    private Vector3 originalPos;
    private Transform camTransform;
    private float shake = 0f;
    
    public float shakeAmount = 0.08f;
    public float decreaseFactor = 2.0f;
   
    void Awake()
    {
        if (camTransform == null)
            camTransform = GetComponent(typeof(Transform)) as Transform;
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shake > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    void Shake()
    {
        shake = 1.0f;
    }
}
