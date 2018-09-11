using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> m_items;
    [SerializeField] Transform m_itempos;
    [SerializeField] ItemSlot[] m_itemslot;

    private void OnValidate()
    {
        if (m_itempos != null)
            m_itemslot = m_itempos.GetComponentsInChildren<ItemSlot>();

        Refresh();
    }

    private void Refresh()
    {
        int i = 0;
        for (; i < m_items.Count && i < m_itemslot.Length; i++)
        {
            m_itemslot[i].m_item = m_items[i];
        }
        for(; i < m_itemslot.Length; i++)
        {
            m_itemslot[i].m_item = null;
        }
    }

    public bool AddItem(Item _item)
    {
        if (invfull())
            return false;

        m_items.Add(_item);
        Refresh();
        return true;
    }

    public bool Removetheitem(Item _item)
    {
        if(m_items.Remove(_item))
        {
            Refresh();
            return true;
        }
        return false;
    }


    public bool invfull()
    {
        return m_items.Count >= m_itemslot.Length;
    }
}
