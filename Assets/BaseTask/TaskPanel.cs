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
        var instance = generateTarget.gameObject;
        foreach (BaseTask i in baseTasks)
        {
            instance.GetComponent<Text>().color = (i.clearFlag) ? Color.green : Color.white;
            instance.GetComponent<Text>().text = i.taskDescription;
                Vector2 vector = instance.transform.position;
                vector.y = vector.y - 70 * index;
                Instantiate(instance, vector, Quaternion.identity, this.transform);
            index++;
        }
        Destroy(generateTarget);
    }
}
