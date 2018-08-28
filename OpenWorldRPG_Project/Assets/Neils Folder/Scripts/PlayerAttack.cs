using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public Animator animator;
    public BoxCollider weaponHitBox;

    public bool shieldEquipped = false;
    public bool blocking = false;

	void Start ()
    {
        animator = GetComponent<Animator>();
        weaponHitBox = GetComponent<BoxCollider>();

        weaponHitBox.isTrigger = true;
        weaponHitBox.enabled = false;

        shieldEquipped = false;
        blocking = false;

}

    private void Update()
    {
        Attack();

        Block();

        //animator.SetBool("meleeAttack", false);
       // animator.SetBool("shieldBlocking", false);
       // animator.SetBool("blocking", false);
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse 0");
            weaponHitBox.enabled = true;
            animator.SetBool("meleeAttack", true);
        }
    }

    void Block()
    {
        if (Input.GetMouseButtonDown(1) && shieldEquipped == true)
        {
            Debug.Log("mouse 1");
            animator.SetBool("shieldBlocking", true);
            blocking = true;

            //incoming damage * 0.15
        }
        if (Input.GetMouseButtonDown(1) && shieldEquipped == false)
        {
            Debug.Log("mouse 1");
            animator.SetBool("blocking", true);
            blocking = true;

            //incoming damage * 0.3
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))  // Enenmy Tag
        {
            weaponHitBox.enabled = false;
        }
    }
}
