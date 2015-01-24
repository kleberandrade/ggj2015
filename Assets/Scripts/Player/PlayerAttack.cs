using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
    public float timeBetweenAttack = 0.2f;
    public AudioClip attackClip;

    private AudioSource playerClip;
    private Animator anim;
    private float timer;

	void Awake () 
    {
        playerClip = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
	}
	
	void Update () 
    {
        timer += Time.deltaTime;
	    if (Input.GetButton("Fire1") && timer >= timeBetweenAttack)
            Attack();
	}

    void Attack()
    {
        timer = 0.0f;
        playerClip.clip = attackClip;
        playerClip.Play();
        anim.SetTrigger("Attack");
    }

    void OnTriggerEnter(Collider other)
    {

    }

    void OnTriggerExit(Collider other)
    {

    }
}
