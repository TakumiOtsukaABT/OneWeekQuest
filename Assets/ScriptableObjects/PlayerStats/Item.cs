using UnityEngine;

[System.Serializable]
public class Item
{
    public int count;
    public string nameItem;
    public Item(string name, int count)
    {
        nameItem = name;
        this.count = count;
    }
}