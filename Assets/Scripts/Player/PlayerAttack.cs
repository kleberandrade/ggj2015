using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
    public float timeAttack = 0.1f;
    public float timeBetweenAttack = 0.2f;
    public AudioClip attackClip;

    private PlayerInput playerInput;
    private AudioSource playerClip;
    private Animator anim;
    private float timer;
    private GameObject item;

	void Awake () 
    {
        playerInput = GetComponent<PlayerInput>();
        playerClip = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
	}
	
	void Update () 
    {
        timer += Time.deltaTime;
	    if (Input.GetButton(playerInput.GetAxis("Attack")) && timer >= timeBetweenAttack)
            Attack();
	}

    void Attack()
    {
        timer = 0.0f;
        playerClip.clip = attackClip;
        playerClip.Play();
        anim.SetTrigger("Attack");

        Invoke("Hit", timeAttack);
    }

    void Hit()
    {
        if (item == null)
            return;

        item.SendMessage("Hit", playerInput.strength);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            item = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            item = null;
        }
    }
}
