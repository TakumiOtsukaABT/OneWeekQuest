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
    [SerializeField] private string[] alreadyDialogue;

    protected override void setDialogueAndItemWithCondition()
    {
        PlayerStatusForReference playerStatus = base.playerData_1.GetComponent<PlayerStatus>().playerStatusForReference;
        PlayerInventory playerInventory = base.playerData_1.GetComponent<PlayerInventory>();
        var status = new List<int>(){ playerStatus.Attack_access, playerStatus.Defence_access, playerStatus.Speed_access };
        var temp = new List<int>(status);
        temp.Sort();
        if (temp[2] >= temp[1] + gosa)
        {
            if (!base.gave)
            {
                if (status[0] == temp[2])
                {
                    if (!playerInventory.hasItem(baaberuId[0]))
                    {
                        base.dialogue = baaberu;
                        base.itemId = baaberuId;
                        base.gave = true;
                    }
                    else
                    {
                        base.dialogue = alreadyDialogue;
                    }
                }
                else if (status[1] == temp[2])
                {
                    if (!playerInventory.hasItem(balanceballId[0]))
                    {
                        base.dialogue = balanceball;
                        base.itemId = balanceballId;
                        base.gave = true;
                    } else
                    {
                        base.dialogue = alreadyDialogue;
                    }
                }
                else
                {
                    if (!playerInventory.hasItem(jitenshaId[0]))
                    {
                        base.dialogue = jitensha;
                        base.itemId = jitenshaId;
                        base.gave = true;
                    } else
                    {
                        base.dialogue = alreadyDialogue;
                    }
                }
            } else
            {
                base.dialogue = after;
                base.itemId = null;
            }
        }
    }
}
