using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Commands")]
public class BaseCommands : ScriptableObject
{
    public List<Command> Commands = new List<Command>();

    public void Add(Command command)
    {
        Commands.Add(command);
    }

    public void RemoveAt(int index)
    {
        Commands.RemoveAt(index);
    }

    public void Clear()
    {
        Commands.Clear();
    }
}
