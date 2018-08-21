using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSwitch : MonoBehaviour {

    public PlayerAttack playerAttack;
    public PlayerShoot playerShoot;
    public PlayerSpells playerSpells;

    public bool attack;
    public bool shoot;
    public bool spell;
    public bool unarmed;

    // Use this for initialization
    void Start()
    {
        attack = false;
        shoot = false;
        spell = false;
        unarmed = true;

        if (playerAttack != null)
        {
            playerAttack.enabled = false;
        }
        else
        {
            Debug.LogError("Player Attack script missing");
        }
        if (playerShoot != null)
        {
            playerShoot.enabled = false;
        }
        else
        {
            Debug.LogError("Player Shoot script missing");
        }
        if (playerSpells != null)
        {
            playerSpells.enabled = false;
        }
        else
        {
            Debug.LogError("Player Spell script missing");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("K pressed");
            unarmed = true;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("J pressed");

            if (unarmed == true)
            {
                unarmed = false;
                attack = true;
            }

            else if(attack == true)
            {
                attack = false;
                shoot = true;
            }

            else if (shoot == true)
            {
                shoot = false;
                spell = true;
            }

            else if(spell == true)
            {
                spell = false;
                attack = true;
            }
        }

        ChangeWeapon();
    }

    void ChangeWeapon()
    {
        if(unarmed)
        {
            attack = false;
            shoot = false;
            spell = false;
            unarmed = true;

            playerAttack.enabled = false;
            playerShoot.enabled = false;
            playerSpells.enabled = false;
        }
        if(attack)
        {
            shoot = false;
            spell = false;
            unarmed = false;
            attack = true;

            playerSpells.enabled = false;
            playerShoot.enabled = false;
            playerAttack.enabled = true;
        }
        if(shoot)
        {
            attack = false;
            spell = false;
            unarmed = false;
            shoot = true;

            playerSpells.enabled = false;
            playerAttack.enabled = false;
            playerShoot.enabled = true;
        }
        if(spell)
        {
            attack = false;
            shoot = false;
            unarmed = false;
            spell = true;

            playerAttack.enabled = false;
            playerShoot.enabled = false;
            playerSpells.enabled = true;
        }
    }

}
