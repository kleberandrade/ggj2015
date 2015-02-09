using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
[AddComponentMenu("Scripts/Enemy/EnemyMovement")]
public class EnemyMovement : MonoBehaviour
{
    private List<Transform> players = new List<Transform>();
    
    private NavMeshAgent nav;
    private Rigidbody enemyRigidbody;
    private Animator anim;

	void Awake () 
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < gos.Length; i++)
            players.Add(gos[i].transform);

        nav = GetComponent<NavMeshAgent>();
	}

	void Update () 
    {
        Vector3 target = ClosestPlayer();
        Turning(target);
        nav.SetDestination(target);  
	}

    void Turning(Vector3 target)
    {
        Vector3 enemyToMouse = target - transform.position;
        enemyToMouse.y = transform.position.y;
        Quaternion newRotation = Quaternion.LookRotation(enemyToMouse);
        enemyRigidbody.MoveRotation(newRotation);
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
