using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHandler : MonoBehaviour
{
    [SerializeField] private BaseTask[] baseTasks;
    [SerializeField] private GameObject taskPanel;

    private void passTask()
    {
        TaskPanel taskPanel = this.taskPanel.GetComponent<TaskPanel>();
        taskPanel._BaseTasks = this.baseTasks;
    }

    public BaseTask getBaseTaskByKey(string key)
    {
        foreach(var i in baseTasks)
        {
            foreach(var j in i.key)
            {
                if (j == key)
                {
                    return i;
                }
            }
        }
        return null;
    }

    public void tickTask(string key)
    {
        foreach (var i in baseTasks)
        {
            i.tickCondition(key);
        }
        passTask();
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (var i in baseTasks)
        {
            i.initDictionary();
        }
        passTask();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
