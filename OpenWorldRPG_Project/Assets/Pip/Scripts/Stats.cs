using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;

[Serializable]
public class Stats
{
    public float m_base; 
    protected float lastcheckvalue = float.MinValue;
    public virtual float Value
    {
        get
        {
            if(isntfull || m_base != lastcheckvalue)
            {
                lastcheckvalue = m_base;
                _value = calculatefinalmod();
                isntfull = false;
            }
            return _value;
        }
    }
    protected bool isntfull = true;
    protected float _value;
    protected readonly List<StatModify> m_statmods;
    public readonly ReadOnlyCollection<StatModify> M_Statmods;         // reference to the list of the stat modifer, but can't make changes


    public Stats()
    {
        m_statmods = new List<StatModify>();
        M_Statmods = m_statmods.AsReadOnly();
    }

    public Stats(float m_basing) : this()
    {
        m_base = m_basing;
    }

    public virtual void addmod(StatModify mod)
    {
        isntfull = true;
        m_statmods.Add(mod);
        m_statmods.Sort(comparemodorder);
    }

    protected virtual int comparemodorder(StatModify a, StatModify b)
    {
        if (a.m_order < b.m_order)                                   // if the item has base stat increase, will calulate BEFORE the percentage
            return -1;
        else if (a.m_order > b.m_order)                              // if item has percentage, it will calculate AFTER the base stat increase
            return 1;
        return 0;                                                    // if(a.m_order == b.m_order) (If both items have the same value, it will 0)
    }


    public virtual bool removemod(StatModify mod)
    {
       if(m_statmods.Remove(mod))
        {
            isntfull = true;
            return true;
        }
        return false;
    }

    public virtual bool Removesource(object sources)
    {
        bool wasitremoved = false;                                  // checks to see if item was removed

        for (int i = m_statmods.Count - 1; i >= 0; i--)             // This will count the item removed from reverse order (9,8,7,6) instead of (0,1,2,3) making less movements in inventory
        {
            if (m_statmods[i].m_source == sources)                  // removed item will have stats changed back to original form
            {
                isntfull = true;
                wasitremoved = true;
                m_statmods.RemoveAt(i);
            }
        }
        return wasitremoved;
    }


    public virtual float calculatefinalmod()
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
        return (float) System.Math.Round(m_finalvalue, 4);
    }
}

