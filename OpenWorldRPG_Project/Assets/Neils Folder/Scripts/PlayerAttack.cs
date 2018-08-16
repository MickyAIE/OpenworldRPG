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
	
    void Attack()
    {
        weaponHitBox.enabled = true;
        //attack animation

    }

    void Block()
    {
        //incoming damage * 0.15
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))  // Enenmy Tag
        {
            //damage enemy health * charge time
            weaponHitBox.enabled = false;
        }
    }
}
