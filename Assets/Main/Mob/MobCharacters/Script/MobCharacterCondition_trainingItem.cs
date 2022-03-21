using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MobCharacterCondition_trainingItem : MobCharacterController
{
    public string[] baaberu;
    public string[] balanceball;
    public string[] jitensha;
    public string[] after;
    public int[] baaberuId;
    public int[] balanceballId;
    public int[] jitenshaId;
    public int gosa;
    protected override void setDialogueAndItemWithCondition()
    {
        PlayerStatusForReference playerStatus = base.playerData_1.GetComponent<PlayerStatus>().playerStatusForReference;
        var status = new List<int>(){ playerStatus.Attack_access, playerStatus.Defence_access, playerStatus.Speed_access };
        var temp = new List<int>(status);
        temp.Sort();
        Debug.Log(temp[0]);
        Debug.Log(temp[1]);
        Debug.Log(temp[2]);
        Debug.Log(status[0]);
        Debug.Log(status[1]);
        Debug.Log(status[2]);
        if (temp[2] >= temp[1] + gosa)
        {
            if (status[0] == temp[2])
            {
                base.dialogue = baaberu;
                base.itemId = baaberuId;
            }
            else if (status[1] == temp[2])
            {
                base.dialogue = balanceball;
                base.itemId = balanceballId;
            }
            else
            {
                base.dialogue = jitensha;
                base.itemId = jitenshaId;
            }
        }
    }
}
