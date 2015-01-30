using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Scripts/Enemy/EnemyMovement")]
public class EnemyMovement : MonoBehaviour
{
    private List<Transform> players = new List<Transform>();
    
    private NavMeshAgent nav;

	void Awake () 
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < gos.Length; i++)
            players.Add(gos[i].transform);

        nav = GetComponent<NavMeshAgent>();
	}

	void Update () 
    {
        nav.SetDestination(ClosestPlayer());
	}

    Vector3 ClosestPlayer()
    {
        Vector3 position = Vector3.one * float.MaxValue;
        float minDist = Vector3.Distance(transform.position, position);

        foreach (Transform p in players)
        {
            float dist = Vector3.Distance(transform.position, p.position);
            if (dist < minDist)
            {
                minDist = dist;
                position = p.position;
            }
        }

        return position;
    }
}
