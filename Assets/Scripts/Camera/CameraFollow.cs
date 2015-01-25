using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public float smoothing = 5.0f;
    public float distance;
    private float minCameraSize;

    private Vector3 offset;
    private GameObject[] players;

    void Start()
    {
        minCameraSize = Camera.main.orthographicSize;
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void FixedUpdate()
    {
		Vector3 theTarget = Vector3.up * players [0].transform.position.y;
		theTarget.x = Mathf.Abs (players [0].transform.position.x - players [1].transform.position.x) / 2.0f + Mathf.Min (players [0].transform.position.x, players [1].transform.position.x);
		theTarget.z = Mathf.Abs(players[0].transform.position.z - players[1].transform.position.z)/2.0f + Mathf.Min(players[0].transform.position.z, players[1].transform.position.z);
		float dist = Mathf.Sqrt (Mathf.Pow(players[0].transform.position.x - players[1].transform.position.x, 2.0f) + Mathf.Pow(players[0].transform.position.z - players[1].transform.position.z,2.0f));
		transform.LookAt (theTarget);
				
		//transform.position = Vector3.Lerp (transform.position, theTarget, smoothing*Time.deltaTime);
		Camera.main.orthographicSize = Mathf.Max(minCameraSize, dist/Camera.main.aspect/Mathf.Log10(dist));
    }
}
