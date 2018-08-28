using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Modtostats
{
    Flat,
    Percent,
}

public class StatModify
{
    public readonly float m_value;
    public readonly Modtostats m_type;
    public readonly int m_order;

    public StatModify(float m_values, Modtostats m_types, int m_orders)
    {
        m_value = m_values;
        m_type = m_types;
        m_order = m_orders;
    }

    public StatModify(float m_value, Modtostats m_types):this (m_value, m_types, (int)m_types)
    { }

}
