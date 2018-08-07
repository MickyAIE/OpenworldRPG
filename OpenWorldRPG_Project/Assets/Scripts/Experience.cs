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
