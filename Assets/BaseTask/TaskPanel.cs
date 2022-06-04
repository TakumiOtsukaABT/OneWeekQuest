using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanel : MonoBehaviour
{
    [SerializeField,ReadOnly] private BaseTask[] baseTasks;
    [SerializeField] private GameObject generateTarget;
    private GameObject generateTarget_value;

    public BaseTask[] _BaseTasks { set {
            baseTasks = value;
            updateText();
        }
    }



    private void updateText()
    {
        var rect = gameObject.GetComponent<RectTransform>().sizeDelta;
        rect.y = baseTasks.Length * 90;
        gameObject.GetComponent<RectTransform>().sizeDelta = rect;
        var index = 0;
        GameObject instance = generateTarget.gameObject;
        deleteExistingTaskPanel();
        foreach (BaseTask i in baseTasks)
        {
            instance.GetComponent<Text>().color = (i.clearFlag) ? Color.green : Color.white;
            instance.GetComponent<Text>().text = i.taskDescription;
            instance.SetActive(true);
            Vector2 vector = instance.transform.position;
            vector.y = vector.y - 50 * index;
            instance.tag = "cloned task";
            Instantiate(instance, vector, Quaternion.identity, this.transform);
            index++;
        }
        instance.SetActive(false);
        instance.tag = "original";
    }

    private void deleteExistingTaskPanel()
    {
        var clones = GameObject.FindGameObjectsWithTag("cloned task");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }
}
