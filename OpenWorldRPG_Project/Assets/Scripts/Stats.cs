using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public float m_base;
    public float Value
    {
        get
        {
            if(isntfull)
            {
                _value = calculatefinalmod();
                isntfull = false;
            }
            return _value;
        }
    }
    private bool isntfull = true;
    private float _value;
    private readonly List<StatModify> m_statmods;


    public Stats(float m_basing)
    {
        m_base = m_basing;
        m_statmods = new List<StatModify>();
    }

    public void addmod(StatModify mod)
    {
        isntfull = true;
        m_statmods.Add(mod);
        m_statmods.Sort(comparemodorder);
    }
    private int comparemodorder(StatModify a, StatModify b)
    {
        if (a.m_order < b.m_order)
            return -1;
        else if (a.m_order > b.m_order)
            return 1;
        return 0; //if(a.m_order == b.m_order)
    }


    public bool removemod(StatModify mod)
    {
        isntfull = true;
        return m_statmods.Remove(mod);
    }


    public float calculatefinalmod()
    {
        float m_finalvalue = m_base;
        float m_sumpercent = 0;

        for(int i = 0; i < m_statmods.Count; i++)
        {
            StatModify mod = m_statmods[i];

            if(mod.m_type == Modtostats.Flat)
            {
                m_finalvalue += m_statmods[i].m_value;
            }
            else if (mod.m_type == Modtostats.PercentAdd)
            {
                m_sumpercent += mod.m_value;
                if(i +1 >= m_statmods.Count || m_statmods[i+1].m_type != Modtostats.PercentAdd)
                {
                    m_finalvalue *= 1 + m_sumpercent;
                    m_sumpercent = 0;
                }
            }
            else if (mod.m_type == Modtostats.Percentmult)
            {
                m_finalvalue *= 1 + mod.m_value;
            }
        }

        return (float)System.Math.Round(m_finalvalue, 4);
    }
}

