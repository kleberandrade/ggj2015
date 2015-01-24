using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    public float walkSpeed = 6.0f;
    public float turnSpeed = 160.0f;

    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigidbody;

	void Awake () 
    {
        anim = GetComponent<Animator>();
        if (anim)
            Debug.LogError("Did not find Animator component.");
        playerRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Turning(h);
        Move(v);
        Animating(h, v);
	}

    void Move(float v)
    {
        movement = v * transform.forward;
        movement = movement * walkSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning(float h)
    {
        Quaternion deltaRotation = Quaternion.Euler(h * Vector3.up * turnSpeed * Time.deltaTime); 
        playerRigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
    }

    void Animating(float h, float v)
    {
        bool walking = v != 0.0f;
        bool turning = h != 0.0f ;

        if (anim)
        {
            anim.SetBool("IsWalking", walking);
            anim.SetBool("IsTurning", turning);
        }
    }
}
