using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image m_image;

    public event Action<Item> m_rightclick;

    private Item pip_item;
    public Item m_item
    {
        get
        {
            return pip_item;
        }
        set
        {
            pip_item = value;
            if (pip_item == null)
            {
                m_image.enabled = false;
            }
            else
            {
                m_image.sprite = pip_item.m_icon;
                m_image.enabled = true;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (m_item != null && m_rightclick != null)
                m_rightclick(m_item);
        }
    }

    protected virtual void OnValidate()
    {
        if (m_image == null)
            m_image = GetComponent<Image>();
    }
}
