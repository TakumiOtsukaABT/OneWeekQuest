using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingList : MonoBehaviour
{
    public List<TrainingCommand> Commands = new List<TrainingCommand>();
    public TrainingDescription trainingDescriptions;


    public void Add(int index)
    {
        TrainingCommand command = new TrainingCommand(trainingDescriptions.commandIdAndDescriptions[index]);
        foreach (TrainingCommand i in Commands)
        {
            if (i == command)
            {
                return;
            }
        }
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
