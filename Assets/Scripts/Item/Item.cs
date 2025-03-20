using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ItemData/Add")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string description;
    public ItemType itemType;

    public enum ItemType
    {
        Attack,
        Defense,
        Health,
        Critical
    }
}
