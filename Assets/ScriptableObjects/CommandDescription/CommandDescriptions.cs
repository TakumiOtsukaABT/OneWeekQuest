using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Commanddescriptionlist")]
public class CommandDescriptions : ScriptableObject
{
    public List<commandIdAndDescription> itemIdAndDescriptions = new List<commandIdAndDescription>();
}

[System.Serializable]
public class commandIdAndDescription
{
    [SerializeField] private int id;
    [SerializeField] private string description;
}