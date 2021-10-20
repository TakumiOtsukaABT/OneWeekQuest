using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
    public ItemDescriptions itemDescriptions;

    public void Add(int index)
    {
        Item item = new Item(itemDescriptions.itemIdAndDescriptions[index], 1);
        foreach (Item i in Items)
        {
            if (i == item)
            {
                i.count+=item.count;
                return;
            }
        }
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