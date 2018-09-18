using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    [SerializeField] GameObject m_invobject;
    [SerializeField] GameObject m_equipobject;
    [SerializeField] KeyCode[] m_toggle;

	void Update ()
    {
		for (int i= 0; i < m_toggle.Length; i++)
        {
            if(Input.GetKeyDown(m_toggle[i]))
            {
                m_invobject.SetActive(!m_invobject.activeSelf);
                m_equipobject.SetActive(!m_equipobject.activeSelf);

                if(m_invobject.activeSelf)
                {
                    ShowMouse();
                }
                else
                {
                    HideMouse();
                }

                break;
            }
        }
	}

    public void ShowMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
