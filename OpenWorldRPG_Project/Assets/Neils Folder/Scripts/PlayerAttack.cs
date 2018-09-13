using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public Animator animator;
    public HitBox weaponHitBox;
    public AnimationEvent animationEvent;
    public BoxCollider hitBox;

    public bool shieldEquipped = false;
    public bool blocking = false;

	void Start ()
    {
        animator = GetComponent<Animator>();

        hitBox.enabled = false;

        weaponHitBox.enabled = false;

        shieldEquipped = false;
        blocking = false;

    }

    private void Update()
    {
        Attack();

        Block();

        if (shieldEquipped == true)
        {
            animator.SetBool("shieldBlocking", true);
        }
        else
        {
            animator.SetBool("shieldBlocking", false);
        }
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("mouse 0");
            Debug.Log("HitBox enabled");

            hitBox.enabled = true;

            weaponHitBox.enabled = true;
            animator.SetBool("meleeAttack", true);
        }
    }

    public void HitBoxDisable(string HitBoxDisable) 
    {
        animator.SetBool("meleeAttack", false);

        weaponHitBox.enabled = false;

        hitBox.enabled = false;
        Debug.Log("HitBox disabled");
    }

    void Block()
    {
        if (Input.GetButtonDown("Fire2") && shieldEquipped == true)
        {
            Debug.Log("mouse 1");
            animator.SetBool("shieldBlocking", true);
            blocking = true;

            //incoming damage * 0.15
        }
        if (Input.GetButtonDown("Fire2") && shieldEquipped == false)
        {
            Debug.Log("mouse 1");
            animator.SetBool("blocking", true);
            blocking = true;

            //incoming damage * 0.3
        }
        if (Input.GetButtonUp("Fire2"))
        {
            Debug.Log("mouse 1 up");

            animator.SetBool("blocking", false);
            blocking = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))  // Enemy Tag
        {
            weaponHitBox.enabled = false;
        }
    }
}
