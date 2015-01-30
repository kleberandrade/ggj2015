using UnityEngine;
using System.Collections;

/// <summary>
/// Movimento do jogador
/// </summary>
[AddComponentMenu("Scripts/Player/PlayerMovement")]
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
    /// Vetor de movimento
    /// </summary>
    private Vector3 movement;

    /// <summary>
    /// Define qual se o jogador é o primeiro ou segundo
    /// </summary>
    private InputManager playerInput;

    /// <summary>
    /// Referência do Animator do jogador
    /// </summary>
    private Animator anim;

    /// <summary>
    /// Referência do corpo rigido do jogador
    /// </summary>
    private Rigidbody playerRigidbody;

    /// <summary>
    /// Armazena as referências
    /// </summary>
	void Awake () 
    {
        playerInput = GetComponent<InputManager>();
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
    /// <param name="v">Vertical</param>
    void Move(float v)
    {
        movement = v * transform.forward;
        movement = movement * walkSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    /// <summary>
    /// Rotação do jogador
    /// </summary>
    /// <param name="h">Horizontal</param>
    void Turning(float h)
    {
        Quaternion deltaRotation = Quaternion.Euler(h * Vector3.up * turnSpeed * Time.deltaTime); 
        playerRigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
    }

    /// <summary>
    /// Determinas as animações de caminhada
    /// </summary>
    /// <param name="h">Horizontal</param>
    /// <param name="v">Vertical</param>
    void Animating(float h, float v)
    {
        bool walking = v != 0.0f;
        anim.SetBool("IsWalking", walking);
    }
}
