using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.SendMessage("Kill");
        }
    }
}
