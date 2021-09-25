using UnityEngine;

[System.Serializable]
public class Command
{
    public int cost;
    public string nameItem;
    public Command(string name, int cost)
    {
        nameItem = name;
        this.cost = cost;
    }
}