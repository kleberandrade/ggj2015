using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAttack))]
public class PlayerHealth : MonoBehaviour
{
    public AudioClip deathClip;

    private PlayerAttack playerAttackScrip;
    private PlayerMovement playerMovementScrip;
    private AudioSource playerAudio;
    private Animator anim;

	void Awake () 
    {
        playerAttackScrip = GetComponent<PlayerAttack>();
        playerMovementScrip = GetComponent<PlayerMovement>();
        playerAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
	}
	
	public void Kill () 
    {
        playerAudio.clip = deathClip;
        playerAudio.Play();
        anim.SetTrigger("Die");
        playerAttackScrip.enabled = false;
        playerMovementScrip.enabled = false;
    }
}
