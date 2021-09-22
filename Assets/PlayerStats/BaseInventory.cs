using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Inventory")]
public class BaseInventory : ScriptableObject
{
    public List<Item> Items;

}

public class Item : MonoBehaviour
{
    public int count;
    public string nameItem;
    public Item(string name,int count)
    {
        nameItem = name;
        this.count = count;
    }
}