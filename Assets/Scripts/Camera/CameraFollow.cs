using UnityEngine;
using System.Collections;

/// <summary>
/// Seguidor dos personagens
/// </summary>
[AddComponentMenu("Scripts/Camera/CameraFollow")]
public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// Tempo para atingir o alvo
    /// </summary>
    public float smoothing = 5.0f;

    /// <summary>
    /// Tamanho minimo da câmera
    /// </summary>
    public float minCameraSize = 4.5f;

    /// <summary>
    /// Offset em relação ao centro
    /// </summary>
    private Vector3 offset;


    /// <summary>
    /// Referência para os jogadores da cena
    /// </summary>
    private GameObject[] players;

    /// <summary>
    /// Centro entre os dois jogadores
    /// </summary>
    private Vector3 target;

    /// <summary>
    /// Distância entre os jogadores
    /// </summary>
    private float distance;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        target = Vector3.Lerp(players[0].transform.position, players[1].transform.position, 0.5f);
        offset = transform.position - Vector3.Lerp(players[0].transform.position, target, 0.5f);
        offset.x = 0.0f;
    }

    void Update()
    {
        // define o centro entre os dois jogadores
        target = Vector3.Lerp(players[0].transform.position, players[1].transform.position, 0.5f) + offset;
        // reposiciona a câmera com base no centro
        transform.position = (transform.position + target) * 0.5f;
        // distância entre os jogadores
        distance = Vector3.Distance(players[0].transform.position, players[1].transform.position);

        if (distance > minCameraSize)
            Camera.main.orthographicSize = Mathf.Max(minCameraSize, distance / Camera.main.aspect / Mathf.Log10(distance));
    }
}

