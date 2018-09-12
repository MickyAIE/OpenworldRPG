using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invmanager : MonoBehaviour
{
    [SerializeField] Inventory m_inventory;
    [SerializeField] Panel m_panel;

    private void Awake()
    {
        m_inventory.m_rightclickactive += Equiping;
        m_panel.m_m_rightclickactive += Unequiping;
    }

    private void Equiping(Item m_item)
    {
        if (m_item is Equipitem)
        {
            Equip((Equipitem)m_item);
        }
    }

    private void Unequiping(Item m_item)
    {
        if (m_item is Equipitem)
        {
            Unequip((Equipitem)m_item);
        }
    }



    public void Equip(Equipitem item)
    {
        if(m_inventory.Removetheitem(item))
        {
            Equipitem previous;
            if (m_panel.Itemadding(item, out previous))
            {
                if (previous != null)
                {
                    m_inventory.AddItem(previous);
                }
            }
            else
            {
                m_inventory.AddItem(item);
            }
        }
    }

    public void Unequip(Equipitem item)
    {
        if (!m_inventory.invfull() && m_panel.Itemremove(item))
        {
            m_inventory.AddItem(item);
        }
    }
}
