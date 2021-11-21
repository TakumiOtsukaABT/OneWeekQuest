using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerData : MonoBehaviour
{
    public List<int> IdList = new List<int>();

    virtual public void Add(int newId)
    {
        foreach (var i in IdList)
        {
            if (i == newId)
            {
                return;
            }
        }
        IdList.Add(newId);
    }

    virtual public void RemoveAt(int index)
    {
        IdList.RemoveAt(index);
    }

    virtual public void Remove(int id)
    {
        foreach (var i in IdList)
        {
            if (i == id)
            {
                IdList.Remove(i);
            }
        }
    }

    virtual public void Clear()
    {
        IdList.Clear();
    }
}
