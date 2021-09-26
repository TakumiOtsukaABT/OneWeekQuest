using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Itemdescriptionlist")]
public class ItemDescriptions : ScriptableObject
{
    public List<itemIdAndDescription> itemIdAndDescriptions = new List<itemIdAndDescription>();
}

[System.Serializable]
public class itemIdAndDescription
{
    [SerializeField] private int id;
    [SerializeField] private string description;
}