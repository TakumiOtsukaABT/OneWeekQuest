using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Inventory")]
public class BaseInventory : ScriptableObject
{
    public List<Item> Items = new List<Item>();
}