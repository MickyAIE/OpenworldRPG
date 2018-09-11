using UnityEngine;

public enum Types
{
    Head,
    Neck,
    Ring,
    Chest,
    Weapon,
    Shield,
    Legs,
    Feet,
}


[CreateAssetMenu]
public class Equipitem : Item
{
    [Header("Flat")]
    public int m_strbonus;
    public int m_agibonus;
    public int m_intbonus;
    public int m_vitbonus;
    [Header("Percent")]
    public float m_strperbonus;
    public float m_agiperbonus;
    public float m_intperbonus;
    public float m_vitperbonus;
    [Space]
    public Types m_types;

}
