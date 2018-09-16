using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statdisplay : MonoBehaviour
{
    public Text m_name;
    public Text m_value;


    private void OnValidate()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        m_name = texts[0];
        m_value = texts[1];
    }

    public void UpdateStatValue()
    {
        Debug.Log("Hello");
    }
}
