using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : BasePlayerData
{
    public List<int> countList = new List<int>();
    public ItemReference itemReference;
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
        var j = itemReference.GetElement(newId);
        switch (j.effect)
        {
            case effectList.None:
                break;
            case effectList.TrainingCommand:
                GetComponent<PlayerTrainingCommandsList>().Add(j.otherId);
                break;
            case effectList.StudyCommand:
                GetComponent<PlayerStudyCommandsList>().AddToList(j.otherId);
                break;
            case effectList.EatCommand:
                GetComponent<PlayerEatCommandsList>().Add(j.otherId);
                break;
        }
    }

    override public void RemoveAt(int index)
    {
        IdList.RemoveAt(index);
        countList.RemoveAt(index);
    }

    override public void Remove(int id)
    {
        int length = IdList.Count;
        for(int i = 0; i < length; i++)
        {
            if (IdList[i] == id)
            {
                countList.Remove(i);
                IdList.Remove(id);
                var j = itemReference.GetElement(id);
                switch (j.effect)
                {
                    case effectList.None:
                        break;
                    case effectList.TrainingCommand:
                        GetComponent<PlayerTrainingCommandsList>().Remove(j.otherId);
                        break;
                    case effectList.StudyCommand:
                        GetComponent<PlayerStudyCommandsList>().Remove(j.otherId);
                        break;
                    case effectList.EatCommand:
                        GetComponent<PlayerEatCommandsList>().Remove(j.otherId);
                        break;
                }
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