using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStudyCommandsList : BasePlayerData
{
    [SerializeField] public List<int> count;
    [SerializeField] private BattleCommandReference battleCommandReference;
    [SerializeField] AlertScript alertScript;
    public override void Add(int newId)
    {
        for (int i =0;i<IdList.Count;i++)
        {
            if (IdList[i] == newId)
            {
                count[i]++;
                AddToBattleCommandList(newId);
                return;
            }
        }
        IdList.Add(newId);
        count.Add(1);
        AddToBattleCommandList(newId);
    }

    private void AddToBattleCommandList(int newId)
    {
        int index_IdList = 0;
        for (int i = 0; i < IdList.Count; i++)
        {
            if (IdList[i] == newId)
            {
                index_IdList = i;
                break;
            }
        }
        foreach( var i in battleCommandReference.elements)
        {
            if (i.study_id == IdList[index_IdList] && count[index_IdList]==i.jukuren_kaisu) {
                gameObject.GetComponent<PlayerBattleCommandList>().Add(i.id);
                alertScript.Activate("新しい技を覚えた!");
                break;
            }
            alertScript.Activate("技を覚えるにはもう少し勉強が必要のようだ");
        }
    }

}
