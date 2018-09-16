using System;
using UnityEngine;

public class EquipPanel : MonoBehaviour
{
    [SerializeField] Transform m_slotparents;
    [SerializeField] Equipslot[] m_equippos;

    public event Action<Item> m_m_rightclickactive;

    private void Awake()
    {
        for (int i = 0; i < m_equippos.Length; i++)
        {
            m_equippos[i].m_rightclick += m_m_rightclickactive;
        }
    }


    private void OnValidate()
    {
        m_equippos = m_slotparents.GetComponentsInChildren<Equipslot>();
    }


    public bool Itemadding(Equipitem _item, out Equipitem previous)
    {
        for(int i = 0; i < m_equippos.Length; i++)
        {
            if (m_equippos[i].m_equipitem.m_type == _item.m_type)            
            {
                previous = (Equipitem)m_equippos[i].m_item;
                m_equippos[i].m_item = _item;
                return true;
            }
        }
        previous = null;
        return false;
    }


    public bool Itemremove(Equipitem item)
    {
        for (int i = 0; i < m_equippos.Length; i++)
        {
            if(m_equippos[i].m_item == item)
            {
                m_equippos[i].m_item = null;
                return true;
            }
        }
        return false;
    }
}
