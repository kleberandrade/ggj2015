using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5.0f;
    public float distance;
    public float minCameraSize;

    private Vector3 offset;
    private GameObject[] players;
    private float sizeStart;

    void Start()
    {
        sizeStart = Camera.main.orthographicSize;
        offset = transform.position - target.position;
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        targetCamPos.x = Mathf.Abs(players[0].transform.position.x - players[1].transform.position.x) / 2 + Mathf.Min(players[0].transform.position.x, players[1].transform.position.x);
        targetCamPos.z = Mathf.Abs(players[0].transform.position.z - players[1].transform.position.z) / 2 + Mathf.Min(players[0].transform.position.z, players[1].transform.position.z) - distance;
        float dist = Vector3.Distance(players[0].transform.position, players[1].transform.position);

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Mathf.Max(minCameraSize, dist * 0.3f), smoothing * Time.deltaTime);
    }
}
