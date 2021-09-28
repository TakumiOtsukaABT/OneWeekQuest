using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Commanddescriptionlist")]
public class CommandDescriptions : ScriptableObject
{
    public List<commandIdAndDescription> commandIdAndDescriptions = new List<commandIdAndDescription>();
}

[System.Serializable]
public class commandIdAndDescription
{
    [SerializeField] private int id;
    [SerializeField] private string description;
    [SerializeField] private string name;
    [SerializeField] private int cost;
}