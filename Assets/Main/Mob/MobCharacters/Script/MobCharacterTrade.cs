using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCharacterTrade : MobCharacterController
{
    public string[] second;
    public string[] dontHave;
    public string[] after;
    public int[] tradeGiveId;
    public int tradeTakeId;
    [SerializeField, ReadOnly] private bool talked = false;
    [SerializeField, ReadOnly] private bool traded = false;

    protected override void setDialogueAndItemWithCondition()
    {
        PlayerInventory playerInventory = base.playerData_1.GetComponent<PlayerInventory>();
        if (traded)
        {
            base.dialogue = after;
            base.itemId = null;
        } else
        {
            if (playerInventory.hasItem(tradeTakeId))
            {
                if (!talked)
                {
                    talked = true;
                }
                else
                {
                    //take and give
                    base.dialogue = second;
                    base.itemId = tradeGiveId;
                    playerInventory.Remove(tradeTakeId);
                    traded = true;
                }
            }
            else
            {
                base.dialogue = dontHave;
                base.itemId = null;
            }
        }
    }
}
