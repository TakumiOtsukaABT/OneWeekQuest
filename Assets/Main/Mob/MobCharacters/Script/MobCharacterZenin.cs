using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCharacterZenin : MobCharacterController
{
    public string[] zeninText;
    public string[] after;
    public int[] ZeninId;
    [SerializeField] private string[] not;
    [SerializeField] private int[] PromisesId;
    protected override void setDialogueAndItemWithCondition()
    {
        PlayerBuff playerBuff = base.playerData_1.GetComponent<PlayerBuff>();
        PlayerInventory playerInventory = base.playerData_1.GetComponent<PlayerInventory>();
        if (!playerInventory.hasItem(ZeninId[0]))
        {
            bool hasAllPromises = true;
            foreach(var i in PromisesId)
            {
                if (playerInventory.getElementId(i) == 99) hasAllPromises = false;
            }
            if (hasAllPromises)
            {
                base.dialogue = zeninText;
                base.itemId = ZeninId;
                base.gave = true;
            }
            else
            {
                base.dialogue = not;
            }
        }
        else
        {
            base.dialogue = after;
            base.itemId = null;
        }

    }
}
