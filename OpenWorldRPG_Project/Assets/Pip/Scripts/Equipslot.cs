using UnityEngine;

public class Equipslot : ItemSlot
{
    public Equipitem m_equipitem;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = m_equipitem.ToString() + " Slot";
    }
}
