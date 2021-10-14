using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPanel : MonoBehaviour
{
    [ReadOnly] private BaseTask[] baseTasks;

    public BaseTask[] _BaseTasks { set {
            baseTasks = value;
            updateText();
        }
    }

    private void updateText()
    {
        // TODO
        Debug.Log(baseTasks);
    }
}
