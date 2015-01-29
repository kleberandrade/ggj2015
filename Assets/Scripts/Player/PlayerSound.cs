using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerSound : MonoBehaviour 
{
    /// <summary>
    /// Som de ataque do jogador
    /// </summary>
    public AudioClip attackClip;

    /// <summary>
    /// Som de morte do jogador
    /// </summary>
    public AudioClip deathClip;

    /// <summary>
    /// Referência para o emissor de som
    /// </summary>
    private AudioSource source;

    /// <summary>
    /// Atribui as referências
    /// </summary>
    void Awake () 
    {
        source = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Toca o som de ataque do jogador
    /// </summary>
    public void PlayAttackClip()
    {
        source.PlayOneShot(attackClip, 1.0f);
    }

    /// <summary>
    /// Toca o som de morte do jogador
    /// </summary>
    public void PlayDeathClip()
    {
        source.PlayOneShot(deathClip, 1.0f);
    }
}
