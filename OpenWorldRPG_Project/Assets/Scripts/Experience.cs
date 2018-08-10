using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    int m_level;
    public static int m_exp;
    int m_exptoup;

    public Slider m_slider;
    public Text m_text;

    private void Start()
    {
        m_level = 1;
        m_exp = 0;
        m_exptoup = 10;

        m_slider.value = m_level;
        m_slider.maxValue = m_exptoup;

        m_text.text = "Level : 1";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            m_exp += 2;
            m_slider.value = m_exp;
        }

        if (m_slider.value >= m_slider.maxValue)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        m_exp = 0;
        m_slider.value = m_exp;

        m_exptoup *= 10;
        m_slider.maxValue = m_exp;

        m_level += 1;
        m_text.text = "Level : " + m_level.ToString();
    }
}

/*   // Wanna check this out Pip? I probably overcomplicated it, but hey :D maths (Loved your code too) This took me ages btw, even with your code lol
 {
    public Text levelText;
    public Text experienceText;
    public Text requiredExperienceText;
    public Slider experienceSlider;

    public static int experience;
    int requiredExperience;             //To level up
    int playerLevel;
    public float experienceGrowth;

    private void Start()
    { 
        playerLevel = 1;
        levelText.text = "Lv 1";

        experience = 0;
        experienceText.text = "" + experience;

        requiredExperience = 100;
        requiredExperienceText.text = "/" + requiredExperience;

        experienceSlider.value = experience;
        experienceSlider.maxValue = requiredExperience;

        experienceGrowth = 1.50f;

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            experience += 20;
            experienceSlider.value = experience;
            experienceText.text = "" + experience;
        }

      
        if (experienceSlider.value >= experienceSlider.maxValue)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        experience = experience -= requiredExperience;
        experienceSlider.value = experience;

        requiredExperience = (int)(requiredExperience * experienceGrowth);
        experienceSlider.maxValue = requiredExperience;

        playerLevel += 1;
        levelText.text = "Lv " + playerLevel;

        requiredExperienceText.text = "/" + requiredExperience;
    }
}
*/
