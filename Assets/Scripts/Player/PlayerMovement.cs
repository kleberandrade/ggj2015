using UnityEngine;
using System.Collections;

/// <summary>
/// Movimento do jogador
/// </summary>
public class PlayerMovement : MonoBehaviour 
{
    /// <summary>
    /// Velocidade do movimento
    /// </summary>
    public float walkSpeed = 6.0f;

    /// <summary>
    /// Velocidade da rotação
    /// </summary>
    public float turnSpeed = 160.0f;

    /// <summary>
    /// Som de caminhada do jogador
    /// </summary>
    public AudioClip walkClip;

    /// <summary>
    /// Vetor de movimento
    /// </summary>
    private Vector3 movement;

    private PlayerInput playerInput;

    /// <summary>
    /// Referência do emissor de audio do jogador
    /// </summary>
    private AudioSource playerAudio;

    /// <summary>
    /// Referência do Animator do jogador
    /// </summary>
    private Animator anim;

    /// <summary>
    /// Referência do corpo rigido do jogador
    /// </summary>
    private Rigidbody playerRigidbody;

    /// <summary>
    /// Início
    /// </summary>
	void Awake () 
    {
        playerInput = GetComponent<PlayerInput>();
        playerAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
	}

    /// <summary>
    /// Atualização com base na física
    /// </summary>
	void FixedUpdate ()
    {
        float h = Input.GetAxisRaw(playerInput.GetAxis("Horizontal"));
        float v = Input.GetAxisRaw(playerInput.GetAxis("Vertical"));

        Turning(h);
        Move(v);
        Animating(h, v);
	}

    /// <summary>
    /// Movimento do jogador
    /// </summary>
    /// <param name="v"></param>
    void Move(float v)
    {
        movement = v * transform.forward;
        movement = movement * walkSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    /// <summary>
    /// Rotação do jogador
    /// </summary>
    /// <param name="h"></param>
    void Turning(float h)
    {
        Quaternion deltaRotation = Quaternion.Euler(h * Vector3.up * turnSpeed * Time.deltaTime); 
        playerRigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
    }

    /// <summary>
    /// Determinas as animações de caminhada
    /// </summary>
    /// <param name="h"></param>
    /// <param name="v"></param>
    void Animating(float h, float v)
    {
        bool walking = v != 0.0f;

        anim.SetBool("IsWalking", walking);

        FootStepSound(walking);
    }

    /// <summary>
    /// Toca o som de caminhada do jogador
    /// </summary>
    /// <param name="walking"></param>
    void FootStepSound(bool walking)
    {
        if (!playerAudio.isPlaying && walking)
        {
            playerAudio.clip = walkClip;
            playerAudio.Play();
        }
    }
}
