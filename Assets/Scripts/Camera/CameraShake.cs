using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Camera/CameraShake")]
public class CameraShake : MonoBehaviour
{
    /// <summary>
    /// Referência para o transfom da câmera
    /// </summary>
    private Transform camTransform;

    /// <summary>
    /// Valor inicial do shake
    /// </summary>
    private float shake = 0f;

    /// <summary>
    /// Total do shake
    /// </summary>
    public float shakeAmount = 0.08f;

    /// <summary>
    /// Fator de decremento do shake
    /// </summary>
    public float decreaseFactor = 2.0f;

    void Awake()
    {
        camTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (shake > 0.0f)
        {
            camTransform.localPosition += Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0.0f;
        }
    }

    public void Shake()
    {
        shake = 1.0f;
    }
}
