using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class EnemyHealth : MonoBehaviour
{
    [Header("Health Attributes")]
    public int m_health = 1;                 // set this value in the inspector
    public int m_currenthealth;              // Current hp


    [Header("Death Attribute")]
    public int m_fallspeed = 2;              // The speed in which the enemy disappears when death occurs
    public AudioClip m_damagesound;          // Soundclip on damage
    public AudioClip m_deathclip;            // Soundclip on death
    private int m_enemyexpgiven = 30;        // experience of the enemy


    [Header("Other things")]
    public Animator m_anim;                  // Animator
    AudioSource m_enemysounds;               // Sound of enemy when hit
    AudioSource m_soundenemy;                // Sound of enemy when death
    CapsuleCollider m_capsule;               // Ref to capsule collider
    ParticleSystem m_particle;               // Ref to particle system
    public GameObject move;                  // Movement Script (Changed to Enemy)
    public float timer = 0f;                 // Timer for death fall

    bool m_falling;                          // Play a animation for the enemy to disappear
    bool m_dead;                             // You know, just to make sure they are dead


    void Awake()
    {
        //m_anim = GetComponent<Animator>();
        m_enemysounds = GetComponentInParent<AudioSource>();
        m_soundenemy = GetComponentInParent<AudioSource>();
        m_particle = GetComponentInChildren<ParticleSystem>();
        m_capsule = GetComponent<CapsuleCollider>();

        timer = 0f;

        m_currenthealth = m_health;
    }


    void Update()
    {
        //timer += 1f;
        if (m_falling)
        {
            transform.Translate(-Vector3.up * m_fallspeed * Time.deltaTime);
        }

        if (timer > 4f)
        {
            gameObject.SetActive(false);
        }
        if (m_currenthealth <= 1.1 && !m_dead)

        {
            
            Death();
        }
    }


    public void Takedamage(int amount)
    {
        if (m_dead)
            return;

        //m_health -= amount;
        m_particle.Play();
        m_enemysounds.clip = m_damagesound;

        if (m_currenthealth <= 0)
        {
            timer += 1f;
            Death();
        }
    }


    public void m_healthbarcurrent(int make)
    {
        m_currenthealth += make;

        if (m_currenthealth < 0)
            m_currenthealth = 0;

        if (m_currenthealth > m_health)
            m_currenthealth = m_health;

        if (m_health < 1)
            m_health = 1;
    }

    void Death()
    {
        m_dead = true;
        m_capsule.isTrigger = true;
        m_anim.SetTrigger("IsDead");

        move.gameObject.transform.Translate(0, -Time.deltaTime / 12, 0, Space.World);
        //move.gameObject.GetComponent<NavMeshAgent>().enabled = false;


        Debug.Log("I died!");
        if (m_soundenemy != null)
        {
            timer += 1f;
            m_soundenemy.clip = m_deathclip;
            m_soundenemy.Play();
            
        }

        Experience.experience += m_enemyexpgiven;

        timer += 1f;
        Destroy(this.gameObject, 2f);
        Destroy(move, 2f); 
    }


    public void m_actualfalling()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        m_falling = true;
        Destroy(gameObject, 5f);
    }

    public void GetHitSucka()
    {
        Debug.Log("Skele got hit!");

        m_health -= 15;
        if(m_health <= 0)
        {
            timer += 1f;
        }
    }
}
