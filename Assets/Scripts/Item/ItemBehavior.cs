using UnityEngine;
using System.Collections;

public class ItemBehavior : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource itemAudio;

    void Awake()
    {
        itemAudio = GetComponent<AudioSource>();
    }

    public void Behave()
    {
        itemAudio.clip = clip;
        itemAudio.Play();
    }
}
