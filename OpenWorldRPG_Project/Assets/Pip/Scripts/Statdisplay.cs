using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statdisplay : MonoBehaviour
{
    public Text m_name;
    public Text m_value;

    private Characterstats _stat;
    public Characterstats made_stat
    {
        get
        {
            return _stat;
        }
        set
        {
            _stat = value;
            UpdateStatValue();
        }
    }


    private void OnValidate()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        m_name = texts[0];
        m_value = texts[1];
    }

    public void UpdateStatValue()
    {
        m_value.text = _stat.Strength.Value.ToString();
        m_value.text = _stat.Agility.Value.ToString();
        m_value.text = _stat.Intelligence.Value.ToString();
        m_value.text = _stat.Vitality.Value.ToString();
    }
}
