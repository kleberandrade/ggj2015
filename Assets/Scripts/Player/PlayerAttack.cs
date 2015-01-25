using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
    public float timeAttack = 0.1f;
    public float timeBetweenAttack = 0.2f;
    public AudioClip attackClip;
	private Color startcolor;
    private PlayerInput playerInput;
    private AudioSource playerClip;
    private Animator anim;
    private float timer;
    private GameObject item, player;
	public ParticleSystem particles;

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
		if (particles != null)
			particles.Play ();

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
		if (other.CompareTag ("Floor")) {
			item = other.gameObject;
			item.particleSystem.Play ();
		}else if (other.CompareTag ("Item")) {
            
						item = other.gameObject;
						startcolor = item.renderer.material.color;
						item.renderer.material.color = Color.yellow;
						item.particleSystem.Play ();
				} 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {	
			item.renderer.material.color = startcolor;
			item = null;
        }
    }
}
