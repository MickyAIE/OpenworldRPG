using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health")]
    public int our_health = 1;                                      // set this in the inspector
    public int our_currenthealth;                                   // our current health
    public Slider ourhealthslider;                                  // add the component to the inspector

    [Header("Mana")]
    public int our_mana = 1;                                        // set this in the inspector
    public int our_currentmana;                                     // our current mana
    public Slider ourmanaslider;                                    // add the component to the inspector


    [Header("Experience Components")]
    public int our_currentexp = 1;                                  // set this in the inspector
    public int our_exp;
    public Slider ourexpslider;                                     // add the component to the inspector

    [Header("Damage Indicator")]
    public float our_damagespeed = 5f;                              // this will make the screen flash when we take damage
    public Image our_damageimage;                                   // this will show an image when we take damage
    public Color our_damagecolour = new Color(1f, 0f, 0f, 0.1f);    // red, with an alpha of .1

    bool our_damage;
    bool our_manause;
    bool our_death;

    [Header("Animator Reference")]
    Animator m_anim;                                                // Animator component
    AudioSource m_audio;                                            // Audio component
    public AudioClip ourdeathclip;                                  // Our death sound
    // Playermovement m_playermovement;                             // Reference to the movement





    private void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_audio = GetComponent<AudioSource>();
        //m_playermovement = GetComponent<Playermovement>;

        our_currenthealth = our_health;
        our_currentmana = our_mana;
        our_currentexp = our_exp;
    }


    private void Update()
    {
        if (our_damage)
        {
            our_damageimage.color = our_damagecolour;
        }
        else
        {
            our_damageimage.color = Color.Lerp(our_damageimage.color, Color.clear, our_damagespeed * Time.deltaTime);
        }
        our_damage = false;
    }

    public void TakeDamage (int m_amount)
    {
        our_damage = true;
        our_currenthealth -= m_amount;
        ourhealthslider.value = our_currenthealth;
        m_audio.Play();
        if(our_currenthealth <= 0 && !our_death)
        {
            Death();
        }
    }

    void Death()
    {
        our_death = true;
        m_anim.SetTrigger("Dead");
        m_audio.clip = ourdeathclip;
        m_audio.Play();

        //m_playermovement.enabled = false
    }
}
