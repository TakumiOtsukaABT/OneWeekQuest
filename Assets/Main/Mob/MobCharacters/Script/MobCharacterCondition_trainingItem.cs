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
        if (temp[2] >= temp[1] + gosa)
        {
            if (!base.gave)
            {
                if (status[0] == temp[2])
                {
                    base.dialogue = baaberu;
                    base.itemId = baaberuId;
                    base.gave = true;
                }
                else if (status[1] == temp[2])
                {
                    base.dialogue = balanceball;
                    base.itemId = balanceballId;
                    base.gave = true;
                }
                else
                {
                    base.dialogue = jitensha;
                    base.itemId = jitenshaId;
                    base.gave = true;
                }
            } else
            {
                base.dialogue = after;
                base.itemId = null;
            }
        }
    }
}
