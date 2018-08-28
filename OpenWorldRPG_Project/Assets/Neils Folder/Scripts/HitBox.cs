using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

    private Transform eTarget;
    public void Seek(Transform enemyTarget) { eTarget = enemyTarget; }
    public Collider hitBox;
    public Vector3 hitPoint;

    public int damage = 20;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 hitPoint = eTarget.position - transform.position;
	}

    private void OnTriggerEnter(Collider other)
    {
       Collider[] colliders = Physics.OverlapBox(transform.position, hitPoint);

        foreach(Collider boxes in colliders)
        {
            if (other.gameObject.tag.Equals("Enemy"))
            {
                Damage(boxes.transform);
            }
        }
    }

    private void Damage(Transform enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.Takedamage(damage, hitPoint);
            Debug.Log("Enemy " + eTarget.name + "should be taking " + enemyHealth.m_health + " damage");
        }
    }
}
