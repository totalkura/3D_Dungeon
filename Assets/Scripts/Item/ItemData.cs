using System;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Empthy
}

public enum  ConsumableTypes
{
    Health,
    Stamina,
    Long
}

[Serializable]
public class  ItemDataConsumable
{
    public ConsumableTypes type;
    public float value;
    public float time;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]

public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;

    [Header("Staking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

}
