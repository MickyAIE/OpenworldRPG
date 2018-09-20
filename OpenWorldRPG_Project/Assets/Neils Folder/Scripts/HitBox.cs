using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

    private Transform eTarget;
    public void Seek(Transform enemyTarget) { eTarget = enemyTarget; }
    public BoxCollider hitBox;
    public Vector3 hitPoint;

    public int damage = 20;

    bool warnMeOnce;
    public PlayerAttack playerAttack;

    void Start ()
    {
        hitBox = GetComponentInChildren<BoxCollider>();

        hitBox.enabled = false;

        warnMeOnce = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (warnMeOnce == true)
        {
            Debug.LogWarning("eTarget = null");
        }

        if (eTarget != null)
        {
            Vector3 hitPoint = eTarget.position - transform.position;
        }
        else
        {
            warnMeOnce = false;
            // #lolololol hacks
        }
	}

    private void OnTriggerEnter(Collider other)
    {
       Collider[] colliders = Physics.OverlapBox(transform.position, hitPoint);

        foreach(Collider boxes in colliders)
        {
            if (other.gameObject.tag.Equals("DamageReciever"))
            {
                hitBox.enabled = false;
                
                Debug.Log("Do damage to enemy");
                //Damage(boxes.transform);

                other.gameObject.transform.SendMessage("GetHitSucka");
               
            }

            if (other.gameObject.tag.Equals("Player"))
            {
                hitBox.enabled = false;

                Debug.Log("Do damage to Player");
                //Damage(boxes.transform);

                if (playerAttack.blocking == false)
                {
                    other.gameObject.transform.SendMessage("GetHitPlaya");
                }
            }

        }

    }

    private void Damage(Transform enemy)
    {
        Debug.Log("In the damage section");
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        Debug.Log("IN THE ENEMYHEALTH SECTION");
        if (enemyHealth != null)
        {
            Debug.Log("NULL?");
            enemyHealth.Takedamage(damage);
            Debug.Log("Enemy " + eTarget.name + "should be taking " + enemyHealth.m_health + " damage");
        }
    }
}
