using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAttack))]
[AddComponentMenu("Scripts/Player/PlayerHealth")]
public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// Referência para o script de ataque
    /// </summary>
    private PlayerAttack playerAttack;

    /// <summary>
    /// Referência para o script de movimento
    /// </summary>
    private PlayerMovement playerMovement;

    /// <summary>
    /// Referência para o script de sons
    /// </summary>
    private PlayerSound playerSound;

    /// <summary>
    /// Referência para o Animator
    /// </summary>
    private Animator anim;

    /// <summary>
    /// Atribui as referências
    /// </summary>
	void Awake () 
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerMovement = GetComponent<PlayerMovement>();
        playerSound = GetComponent<PlayerSound>();
        anim = GetComponent<Animator>();
	}
	
    /// <summary>
    /// Mata o jogador
    /// </summary>
	public void Kill () 
    {
        playerSound.PlayDeathClip();
        anim.SetTrigger("Die");
        playerAttack.enabled = false;
        playerMovement.enabled = false;
    }
}
