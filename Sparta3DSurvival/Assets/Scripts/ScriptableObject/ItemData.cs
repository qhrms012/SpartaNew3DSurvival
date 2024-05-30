using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Equipable,
    Consumable,
    Resource,

}

public enum ConsumableType
{
    Health,
    Hunger
}

[Serializable]
public class ItemDataConsumbale
{
    public ConsumableType type;
    public float value;
}



[CreateAssetMenu(fileName = "Item", menuName = "New Item")]

public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")]
    public bool conStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumbale[] consumbales;


    public float effectDuration; // 아이템 효과 지속 시간
    public EffectType effectType; // 아이템 효과 유형
    public enum EffectType
    {
        SpeedBoost,
        None
    }
}
