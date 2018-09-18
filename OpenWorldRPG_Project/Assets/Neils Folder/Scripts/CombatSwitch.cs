using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSwitch : MonoBehaviour {

    public PlayerAttack playerAttack;
    public PlayerShoot playerShoot;
    public PlayerSpells playerSpells;
    public Animator animator;

    public bool attack;
    //public bool shoot;
    //public bool spell;
    public bool unarmed;

    public GameObject weapon;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

        attack = false;
        //shoot = false;
        //spell = false;
        unarmed = true;

        animator.SetBool("inCombat", false);

        if (playerAttack != null)
        {
            playerAttack.enabled = false;
        }
        else
        {
            Debug.LogError("Player Attack script missing");
        }
        /*if (playerShoot != null)
        {
            playerShoot.enabled = false;
        }
        else
        {
            Debug.LogError("Player Shoot script missing");
        }*/
        if (playerSpells != null)
        {
            playerSpells.enabled = false;
        }
        else
        {
            Debug.LogError("Player Spell script missing");
        }


        weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("K pressed");
            unarmed = true;
            animator.SetBool("changingWeapon", true);

            weapon.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("J pressed");

            weapon.SetActive(true);

            if (unarmed == true)
            {
                unarmed = false;
                attack = true;
                animator.SetBool("changingWeapon", true);
                animator.SetBool("inCombat", false);
            }

            else if(attack == true)
            {
                attack = false;
                unarmed = true;
                animator.SetBool("changingWeapon", true);
                animator.SetBool("inCombat", true);
            }

            /*else if (shoot == true)
            {
                shoot = false;
                spell = true;
                animator.SetBool("changingWeapon", true);
                animator.SetBool("inCombat", true);
            }

            else if(spell == true)
            {
                spell = false;
                attack = true;
                animator.SetBool("changingWeapon", true);
                animator.SetBool("inCombat", true);
            }
            */
        }

        ChangeWeapon();

    }

    void ChangeWeapon()
    {
        if(unarmed)
        {
            attack = false;
            //shoot = false;
            //spell = false;
            unarmed = true;

            playerAttack.enabled = false;
            playerShoot.enabled = false;
            playerSpells.enabled = false;

            animator.SetBool("inCombat", false);

            animator.SetBool("changingWeapon", false);

            animator.SetBool("rangedEquipped", false);
            animator.SetBool("magicEquipped", false);
            animator.SetBool("meleeEquipped", false);
        }
        if(attack)
        {
            //shoot = false;
            //spell = false;
            unarmed = false;
            attack = true;

            playerSpells.enabled = false;
            playerShoot.enabled = false;
            playerAttack.enabled = true;

            animator.SetBool("inCombat", true);
            animator.SetBool("rangedEquipped", false);
            animator.SetBool("magicEquipped", false);

            animator.SetBool("meleeEquipped", true);

            animator.SetBool("changingWeapon", false);
        }
        /*if(shoot)
        {
            attack = false;
            spell = false;
            unarmed = false;
            shoot = true;

            playerSpells.enabled = false;
            playerAttack.enabled = false;
            playerShoot.enabled = true;

            animator.SetBool("inCombat", true);
            animator.SetBool("meleeEquipped", false);
            animator.SetBool("magicEquipped", false);

            animator.SetBool("rangedEquipped", true);

            animator.SetBool("changingWeapon", false);
        }
        if(spell)
        {
            attack = false;
            //shoot = false;
            unarmed = false;
            spell = true;

            playerAttack.enabled = false;
            playerShoot.enabled = false;
            playerSpells.enabled = true;

            animator.SetBool("inCombat", true);
            animator.SetBool("meleeEquipped", false);
            animator.SetBool("rangedEquipped", false);

            animator.SetBool("magicEquipped", true);

            animator.SetBool("changingWeapon", false);
        }
        */
    }

}
