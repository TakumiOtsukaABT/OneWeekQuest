using UnityEngine;

[System.Serializable]
public class Command
{
    public commandIdAndDescription command;

    public Command(commandIdAndDescription newCommand)
    {
        command = newCommand;
    }
}