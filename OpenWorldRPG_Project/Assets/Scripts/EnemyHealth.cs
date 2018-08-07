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
    public int m_enemyexpgiven = 1;                    // experience of the enemy
    public Slider m_enemyslider;             // enemy health slider (to be fixed)


    [Header("Other things")]
    Animator m_anim;                         // Animator
    AudioSource m_enemysounds;               // Sound of enemy when hit
    AudioSource m_soundenemy;                // Sound of enemy when death
    CapsuleCollider m_capsule;               // Ref to capsule collider
    ParticleSystem m_particle;               // Ref to particle system



    bool m_falling;                          // Play a animation for the enemy to disappear
    bool m_dead;                             // You know, just to make sure they are dead


    void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_enemysounds = GetComponent<AudioSource>();
        m_soundenemy = GetComponent<AudioSource>();
        m_particle = GetComponentInChildren<ParticleSystem>();
        m_capsule = GetComponent<CapsuleCollider>();
        

        m_currenthealth = m_health;
    }


    void Update()
    {
        if (m_falling)
        {
            transform.Translate(-Vector3.up * m_fallspeed * Time.deltaTime);
        }
    }


    public void Takedamage(int amount, Vector3 hitPoint)
    {
        if (m_dead)
            return;

        m_health -= amount;
        m_particle.transform.position = hitPoint;
        m_particle.Play();
        m_enemysounds.clip = m_damagesound;

        if (m_currenthealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        m_dead = true;
        m_capsule.isTrigger = true;
        m_anim.SetTrigger("Dead");
        m_soundenemy.clip = m_deathclip;
        m_soundenemy.Play();
    }

    public void m_actualfalling()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        m_falling = true;
        Experience.m_exp += m_enemyexpgiven;
        Destroy(gameObject, 5f);
    }

}
