using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStudyCommandsList : BasePlayerData
{
    [SerializeField] private List<int> count;
    public override void Add(int newId)
    {
        for (int i =0;i<IdList.Count;i++)
        {
            if (IdList[i] == newId)
            {
                count[i]++;
                return;
            }
        }
        IdList.Add(newId);
        count.Add(1);
    }
}
