using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseTask 
{
    private bool clearFlag = false;
    public string taskDescription;
    public string[] key;
    public int[] count; 
    private Dictionary<string, int> completeCondition;
    private Dictionary<string, int> currentCondition;

    public void initDictionary()
    {
        for (int i = 0;i<key.Length;i++) {
            completeCondition.Add(key[i], count[i]);
            currentCondition.Add(key[i], 0);
        }
    }
    private void checkClear()
    {
        int conditionCount = completeCondition.Count;
        foreach(string key in completeCondition.Keys)
        {
            if (currentCondition[key] > completeCondition[key])
            {
                conditionCount--;
            }
        }
        if (conditionCount < 0)
        {
            clearFlag = true;
        }
    }

    public void tickCondition(string key)
    {
        if (currentCondition.ContainsKey(key))
        {
            currentCondition[key]++;
        }
        checkClear();
    }
}
