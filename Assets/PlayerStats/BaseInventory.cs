using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Inventory")]
public class BaseInventory : ScriptableObject
{
    public List<Item> Items = new List<Item>();

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void RemoveAt(int index)
    {
        Items.RemoveAt(index);
    }

    public void Clear()
    {
        Items.Clear();
    }
}