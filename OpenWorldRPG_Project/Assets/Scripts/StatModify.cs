using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Modtostats
{
    Flat,
    PercentAdd,
    Percentmult,
}

public class StatModify
{
    public readonly float m_value;
    public readonly Modtostats m_type;
    public readonly int m_order;
    public readonly object m_source;

    public StatModify(float m_values, Modtostats m_types, int m_orders, object m_sources = null)                                           
    {
        m_value = m_values;
        m_type = m_types;
        m_order = m_orders;
        m_source = m_sources;
    }

    public StatModify(float m_value, Modtostats m_types):this (m_value, m_types, (int)m_types, null) { }                            // This doesn't need the order or the source
    
    public StatModify(float m_value, Modtostats m_types, int m_orders) : this (m_value, m_types, m_orders, null){ }                 // This only needs the order, not the source

    public StatModify(float m_value, Modtostats m_types, object m_source) : this(m_value, m_types, (int)m_types, m_source) { }      // This only needs the source, not the order
}
