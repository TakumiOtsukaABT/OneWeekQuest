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

    public int getElementId(int id)
    {
        foreach (var i in IdList)
        {
            if (i.Equals(id))
            {
                return i;
            }
        }
        return 99;
    }

    public int getElementCount(int id)
    {
        for (int i =0; i<IdList.Count;i++)
        {
            if (IdList[i].Equals(id))
            {
                return countList[i];
            }
        }
        return 99;
    }

    public bool hasItem(int id)
    {
        foreach(int i in IdList) {
            if (id == i)
            {
                return true;
            }
        }
        return false;
    }

    override public void Clear()
    {
        IdList.Clear();
        countList.Clear();
    }

}
