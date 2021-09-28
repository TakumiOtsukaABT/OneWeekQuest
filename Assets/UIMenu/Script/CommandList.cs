using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandList : MonoBehaviour
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
