using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerSound : MonoBehaviour 
{
    public AudioClip attackClip;
    public AudioClip deathClip;

    private AudioSource source;

    void Awake () 
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayAttackClip()
    {
        source.PlayOneShot(attackClip, 1.0f);
    }

    public void PlayDeathClip()
    {
        source.PlayOneShot(deathClip, 1.0f);
    }
}
