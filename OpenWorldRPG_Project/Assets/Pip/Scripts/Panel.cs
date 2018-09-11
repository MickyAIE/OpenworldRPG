using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField] Transform slotposparents;
    [SerializeField] Equipslot[] equippos;

    private void OnValidate()
    {
        equippos = slotposparents.GetComponentsInChildren<Equipslot>();
    }

    public bool Itemadding(Equipitem item)
    {
        for(int i = 0; i < equippos.Length; i++)
        {
            if(equippos[i].m_equipitem = item.m_equipitem)
            {
                equippos[i].m_item = item;
                return true;
            }
        }
        return false;
    }

    public bool Itemremove(Equipitem item)
    {
        for (int i = 0; i < equippos.Length; i++)
        {
            if(equippos[i].m_item == item.Equipment)

        }



    }
}
