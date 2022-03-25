using UnityEngine;

[System.Serializable]
public class Item:BaseItemType
{
    public int count;
    public effectList effect;
    public int otherId;
}

public enum effectList
{
    None,
    TrainingCommand,
    StudyCommand,
    EatCommand
};