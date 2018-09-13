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
    public float m_healthbar;


    [Header("Death Attribute")]
    public int m_fallspeed = 2;              // The speed in which the enemy disappears when death occurs
    public AudioClip m_damagesound;          // Soundclip on damage
    public AudioClip m_deathclip;            // Soundclip on death
    public int m_enemyexpgiven = 1;          // experience of the enemy
    public Slider m_enemyslider;             // enemy health slider (to be fixed)


    [Header("Other things")]
    Animator m_anim;                         // Animator
    AudioSource m_enemysounds;               // Sound of enemy when hit
    AudioSource m_soundenemy;                // Sound of enemy when death
    CapsuleCollider m_capsule;               // Ref to capsule collider
    ParticleSystem m_particle;               // Ref to particle system



    bool m_falling;                          // Play a animation for the enemy to disappear
    bool m_dead;                             // You know, just to make sure they are dead


    private void Start()
    {
        m_healthbar = Screen.width / 8;
    }

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
        m_healthbarcurrent(0);
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

    private void OnGUI()
    {
        Vector2 m_targetpostition;
        m_targetpostition = Camera.main.WorldToScreenPoint (transform.position);

        GUI.Box(new Rect(700, 10, m_healthbar, 20), m_currenthealth + "/" + m_health);
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

        m_healthbar = (Screen.width / 8) * (m_currenthealth / (float)m_health);
    }

    public void Death()
    {
        m_dead = true;
        m_capsule.isTrigger = true;
        m_anim.SetTrigger("Dead");
        m_soundenemy.clip = m_deathclip;
        m_soundenemy.Play();
        //Experience.experience += m_enemyexpgiven;
    }

    public void m_actualfalling()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        m_falling = true;
        Destroy(gameObject, 5f);
    }
}
