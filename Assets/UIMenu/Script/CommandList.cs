using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandList : MonoBehaviour
{
    public List<Command> Commands = new List<Command>();
    public CommandDescriptions commandDescriptions;


    public void Add(int index)
    {
        Command command = new Command(commandDescriptions.commandIdAndDescriptions[index]);
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
