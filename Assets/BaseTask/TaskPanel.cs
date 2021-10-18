using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanel : MonoBehaviour
{
    [SerializeField,ReadOnly] private BaseTask[] baseTasks;
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
        var index = 0;
        foreach (BaseTask i in baseTasks)
        {
            generateTarget.GetComponent<Text>().color = (i.clearFlag) ? Color.green : Color.white;
            generateTarget.GetComponent<Text>().text = i.taskDescription;
            if (index > 0)
            {
                Vector2 vector = generateTarget.transform.position;
                vector.y = vector.y - 70 * index;
                Instantiate(generateTarget,vector, Quaternion.identity, this.transform);
            }
            index++;
        }
    }
}
