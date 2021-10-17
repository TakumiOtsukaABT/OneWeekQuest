using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPanel : MonoBehaviour
{
    [ReadOnly] private BaseTask[] baseTasks;
    [SerializeField] private GameObject generateTarget;

    public BaseTask[] _BaseTasks { set {
            baseTasks = value;
            updateText();
        }
    }

    private void updateText()
    {
        var rect = gameObject.GetComponent<RectTransform>().sizeDelta;
        rect.y = baseTasks.Length * 100;
        gameObject.GetComponent<RectTransform>().sizeDelta = rect;
        // TODO
        Debug.Log(baseTasks);
    }
}
