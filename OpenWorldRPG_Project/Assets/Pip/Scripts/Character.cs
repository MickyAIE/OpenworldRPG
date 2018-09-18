using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Characterstats m_strength;
    public Characterstats m_agility;
    public Characterstats m_intelligence;
    public Characterstats m_vitality;

    [SerializeField] Inventory m_inventory;
    [SerializeField] EquipPanel m_panel;
    [SerializeField] Statpanel m_statpanel;

    private void Start()
    {
        m_statpanel.SetStats(m_strength, m_agility, m_intelligence, m_vitality);
        m_statpanel.UpdatedValue();

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
                    previous.Unequiped(this);
                    m_statpanel.UpdatedValue();
                }
                item.Equiped(this);
                m_statpanel.UpdatedValue();
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
            item.Unequiped(this);
            m_statpanel.UpdatedValue();
            m_inventory.AddItem(item);
        }
    }
}
