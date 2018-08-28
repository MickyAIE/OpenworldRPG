using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spellbook : MonoBehaviour
{
    public class Spells
    {
        public Texture m_icon;
        public string m_name;
        public string m_decrip;
        public int m_manacost;
        public int m_id;
    }

    public Spellbook(Spellbook ab)
    {

        m_icon = ab.m_icon;
        m_name = ab.m_name;
        m_manacost = ab.m_manacost;
        m_descrip = ab.m_descrip;
        m_id = ab.m_id;
	}

    public virtual void Cast()
    {
        Debug.Log("Fix");
    }


    
}
