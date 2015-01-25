using UnityEngine;
using System.Collections;

public class MoveToCamera : MonoBehaviour 
{
    private static float volume = 0.3f;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;
    }

    void Start()
    {
        transform.position = Camera.main.transform.position;
    }
}
