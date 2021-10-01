using UnityEngine;

[System.Serializable]
public class Item
{
    public int count;
    public itemIdAndDescription itemDescription;
    public Item(itemIdAndDescription newItem, int count)
    {
        itemDescription = newItem;
        this.count = count;
    }
}