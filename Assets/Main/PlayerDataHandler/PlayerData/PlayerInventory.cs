using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : BasePlayerData
{
    public List<int> countList = new List<int>();
    override public void Add(int newId)
    {
        for (var i =0;i < IdList.Count;i++)
        {
            if (IdList[i] == newId)
            {
                countList[i]++;
                return;
            }
        }
        IdList.Add(newId);
        countList.Add(1);
    }

    override public void RemoveAt(int index)
    {
        IdList.RemoveAt(index);
        countList.RemoveAt(index);
    }

    override public void Remove(int id)
    {
        foreach (var i in IdList)
        {
            if (i == id)
            {
                countList.Remove(IdList.IndexOf(i));
                IdList.Remove(i);
            }
        }
    }

    override public void Clear()
    {
        IdList.Clear();
        countList.Clear();
    }

}
