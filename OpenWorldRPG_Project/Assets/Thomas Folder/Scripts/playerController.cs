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
    public GameObject Player;

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
                playeranim.SetBool("IsWalking", false);
                playeranim.SetBool("IsIdle", false);
                playeranim.SetBool("IsRunning", true);
            }
            else
            {
                playeranim.SetBool("IsIdle", true);
                playeranim.SetBool("IsWalking", false);
                playeranim.SetBool("IsRunning", false);
            }

            if (translation != 0)
            {
                playeranim.SetBool("IsWalking", false);
                playeranim.SetBool("IsIdle", false);
                playeranim.SetBool("IsRunning", true);
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
                playeranim.SetBool("IsWalking", true);
                playeranim.SetBool("IsIdle", false);
                playeranim.SetBool("IsRunning", false);
                playeranim.SetBool("IsJumping", false);
            }
            else
            {
                playeranim.SetBool("IsIdle", true);
                playeranim.SetBool("IsWalking", false);
                playeranim.SetBool("IsRunning", false);
                playeranim.SetBool("IsJumping", false);
            }

            if (translation != 0)
            {
                playeranim.SetBool("IsWalking", true);
                playeranim.SetBool("IsIdle", false);
                playeranim.SetBool("IsRunning", false);
                playeranim.SetBool("IsJumping", false);
            }
        }
        else
        {
            playeranim.SetBool("IsIdle", false);
            playeranim.SetBool("IsWalking", false);
            playeranim.SetBool("IsJumping", false);
        }

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rigd.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            isJumping = true;
            playeranim.SetBool("IsWalking", false);
            playeranim.SetBool("IsIdle", false);
            playeranim.SetBool("IsRunning", false);
            playeranim.SetBool("IsJumping", true);
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
