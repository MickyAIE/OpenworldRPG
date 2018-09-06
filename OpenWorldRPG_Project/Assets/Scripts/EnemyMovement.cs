using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {



    //This is the enemy template script for enemy movement



    float m_enemyPosition;
    public float m_moveSpeed = 10f;
    public float m_targetDistance = 20f;
    GameObject Enemy;

    private bool m_EnemyFollow;

    float m_playerPosition; //might not need yet, could be useful if tracking two players and finding closest 
    float m_playerDistance;
    GameObject m_Player;
    public Transform Player;

    private Rigidbody m_Rigidbody;
    private NavMeshAgent m_EnemyNav;


	// Use this for initialization
	private void Awake ()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_Rigidbody = GetComponent<Rigidbody>();

        m_EnemyNav = GetComponent<NavMeshAgent>();
        m_EnemyFollow = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //m_playerPosition = new Vector3  (Player.transform);
        //Player.transform.position = new Vector3(playerposition);
        

        float m_PlayerDistance = (m_Player.transform.position - transform.position).magnitude; //use the player distance to see if player is in range
        float m_AtPlayer = 0.2f;

        if(m_PlayerDistance > m_AtPlayer)
        {
            m_EnemyNav.SetDestination(m_Player.transform.position);
            m_EnemyNav.isStopped = false;
        }
        else
        {
            m_EnemyNav.isStopped = true;
            m_moveSpeed = 0;
        }

        //m_playerDistance = m_playerPosition - m_enemyPosition;

        m_EnemyNav.SetDestination(m_Player.transform.position);

		//if (m_Player) { }
        if (m_EnemyFollow == false)
        {
            m_EnemyNav.isStopped = true;
            return;
        }
        if (m_EnemyFollow == true)
        {
            transform.LookAt(Player);
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player") == true)
        {
            m_EnemyFollow = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player") == true)
        {
            m_EnemyFollow = false;
        }
    
    }

}
