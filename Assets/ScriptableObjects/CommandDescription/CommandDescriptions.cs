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
    [SerializeField] public int id;
    [SerializeField] public string description;
    [SerializeField] public string name;
    [SerializeField] public int cost;
}