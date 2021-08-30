using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Inventory")]
public class BaseInventory : ScriptableObject
{
    public Item[] Items;
}
public class Item : MonoBehaviour
{
    int count;
    string name;
}