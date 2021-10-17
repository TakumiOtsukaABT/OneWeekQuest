using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseTask 
{
    private bool clearFlag = false;
    private string taskDescription;
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
    public void checkClear()
    {
        foreach(int value in completeCondition.Values)
        {
            return;
        }
        return;
    }

    public void tickCondition(string key)
    {
        return;
    }
}
