using UnityEngine;

public enum EquipTypes
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
    [Space]
    public float m_strperbonus;
    public float m_agiperbonus;
    public float m_intperbonus;
    public float m_vitperbonus;
    [Space]
    public EquipTypes m_equiptypes;

}
