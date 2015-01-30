using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Enemy/EnemyAttack")]
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
