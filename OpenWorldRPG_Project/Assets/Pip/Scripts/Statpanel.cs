using System;
using UnityEngine;

public class Statpanel : MonoBehaviour
{

    [SerializeField] Statdisplay[] m_display;
    [SerializeField] string[] m_statname;

    private Characterstats[] m_stats;



    private void OnValidate()
    {
        m_display = GetComponentsInChildren<Statdisplay>();
        UpdatedNames();
    }


    public void SetStats(params Characterstats[] m_charstats)
    {
        m_stats = m_charstats;

        if(m_stats.Length > m_display.Length)
        {
            Debug.LogError("I can't display this much");
            return;
        }

        for(int i = 0; i < m_display.Length; i++)
        {
            m_display[i].gameObject.SetActive (i < m_stats.Length);
        }
    }


    public void UpdatedValue()
    {
        for(int i = 0; i < m_stats.Length; i++)
        {
            m_display[i].UpdateStatValue();
        }
    }


    public void UpdatedNames()
    {
        for (int i = 0; i < m_statname.Length; i++)
        {
            m_display[i].m_name.text = m_statname[i];
        }
    }
}
