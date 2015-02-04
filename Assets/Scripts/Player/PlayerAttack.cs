using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Player/PlayerSound")]
public class PlayerAttack : MonoBehaviour 
{
    /// <summary>
    /// Tempo da animação de ataque
    /// </summary>
    public float timeAttack = 0.1f;

    /// <summary>
    /// Tempo entre os ataques
    /// </summary>
    public float timeBetweenAttack = 0.2f;

    /// <summary>
    /// Referência para os sons do jogador
    /// </summary>
    private PlayerSound playerSound;
    
    /// <summary>
    /// Referência para as entradas do jogador
    /// </summary>
    private PlayerInput playerInput;

    /// <summary>
    /// Referência para o Animator
    /// </summary>
    private Animator anim;

    /// <summary>
    /// Acumulador de tempo
    /// </summary>
    private float timer;

    /// <summary>
    /// Referência para objetos pertos da cena
    /// </summary>
    private GameObject item;

    /// <summary>
    /// Atribui as referências
    /// </summary>
	void Awake () 
    {
        playerSound = GetComponent<PlayerSound>();
        playerInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
	}
	
    /// <summary>
    /// Loop de ataque
    /// </summary>
	void Update () 
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Attack" + playerInput.GetControlNumber) && timer >= timeBetweenAttack)
            Attack();
	}

    /// <summary>
    /// Método pra ataque do jogador
    /// </summary>
    void Attack()
    {
        timer = 0.0f;
        playerSound.PlayAttackClip();
        anim.SetTrigger("Attack");
        Invoke("Hit", timeAttack);
    }

    /// <summary>
    /// Verifica se tem objeto para colidir
    /// </summary>
    void Hit()
    {
        if (item == null)
            return;

        //item.SendMessage("Hit", playerInput.strength);
    }

    /// <summary>
    /// Entrou na zona de colisão de itens
    /// </summary>
    /// <param name="other">Item a ser tocado</param>
    void OnTriggerEnter(Collider other)
    {
		if (other.CompareTag ("Item"))
            item = other.gameObject;
    }

    /// <summary>
    /// Saiu da zona de colisão de itens
    /// </summary>
    /// <param name="other">Item tocado</param>
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag ("Item"))
			item = null;
    }
}
