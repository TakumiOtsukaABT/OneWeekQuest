using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseTask 
{
    private bool clearFlag = false;
    private string taskDescription;
    public Dictionary<string, int> completeCondition;

    virtual public void checkClear()
    {
        foreach(int value in completeCondition.Values)
        {
            return;
        }
        return;
    }

    virtual public void tickCondition(string key)
    {
        return;
    }
}
