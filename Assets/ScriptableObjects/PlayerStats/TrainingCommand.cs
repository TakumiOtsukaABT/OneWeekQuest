using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class TrainingCommand
{
    public trainingCommandIdAndDescription trainingCommand;
    public TrainingCommand(trainingCommandIdAndDescription newCommand)
    {
        trainingCommand = newCommand;
    }
}
