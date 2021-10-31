using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "MyScriptable/TrainCommanddescriptionlist")]
public class TrainingDescription : ScriptableObject
{
    public List<trainingCommandIdAndDescription> commandIdAndDescriptions = new List<trainingCommandIdAndDescription>();
}

[System.Serializable]
public class trainingCommandIdAndDescription
{
    [SerializeField] public int id;
    [SerializeField] public string name;
    [SerializeField] public string description;
    [SerializeField] public int power;
}