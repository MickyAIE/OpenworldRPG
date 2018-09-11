using UnityEngine.UI;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image m_image;

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

    protected virtual void OnValidate()
    {
        if (m_image == null)
            m_image = GetComponent<Image>();
    }
}
