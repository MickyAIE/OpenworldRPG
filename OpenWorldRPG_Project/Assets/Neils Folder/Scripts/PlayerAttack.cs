using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public Animator animator;
    public BoxCollider weaponHitBox;

	void Start ()
    {
        animator = GetComponent<Animator>();
        weaponHitBox = GetComponent<BoxCollider>();

        weaponHitBox.isTrigger = true;
        weaponHitBox.enabled = false;

    }

    private void Update()
    {
        Attack();

        Block();
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weaponHitBox.enabled = true;
            //attack animation
        }
    }

    void Block()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //block animation
            //incoming damage * 0.15
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
