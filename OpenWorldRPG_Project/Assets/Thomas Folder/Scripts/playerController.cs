using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float StartSpeed = 10f;
    public float speed;
    public float Rspeed = 13f;
    public float jumpForce;
    public bool running = false;
    public Rigidbody rigd;
    private Animator playeranim;
    private bool isJumping;

	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        playeranim = GetComponent<Animator>();
        running = false;
        speed = StartSpeed;
        rigd = GetComponent<Rigidbody>();
        isJumping = false;
        
	}
	
	void Update () {

        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

        if(Input.GetButton("Fire3"))
        {
            if (straffe != 0)
            {
                playeranim.SetBool("isWalking", false);
                playeranim.SetBool("isIdle", false);
                playeranim.SetBool("isRunning", true);
            }
            else
            {
                playeranim.SetBool("isIdle", true);
                playeranim.SetBool("isWalking", false);
                playeranim.SetBool("isRunning", false);
            }

            if (translation != 0)
            {
                playeranim.SetBool("isWalking", false);
                playeranim.SetBool("isIdle", false);
                playeranim.SetBool("isRunning", true);
            }
            running = true;
            speed = Rspeed;

        }
        else
        {
            running = false;
            speed = StartSpeed;
        }

        if (running == false)
        {
            if (straffe != 0)
            {
                playeranim.SetBool("isWalking", true);
                playeranim.SetBool("isIdle", false);
                playeranim.SetBool("isRunning", false);
            }
            else
            {
                playeranim.SetBool("isIdle", true);
                playeranim.SetBool("isWalking", false);
                playeranim.SetBool("isRunning", false);
            }

            if (translation != 0)
            {
                playeranim.SetBool("isWalking", true);
                playeranim.SetBool("isIdle", false);
                playeranim.SetBool("isRunning", false);
            }
        }
        else
        {
            playeranim.SetBool("isIdle", false);
            playeranim.SetBool("isWalking", false);
        }

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rigd.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            isJumping = true;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "floor")
        {
            isJumping = false;
        }
    }
}
