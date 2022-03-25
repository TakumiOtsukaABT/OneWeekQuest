using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCharacterConditionCoffee : MobCharacterController
{
    public string[] coffee;
    public string[] after;
    public int[] coffeeId;
    [SerializeField] private string[] notBuffed;
    [SerializeField] private int chocolateBuffId;
    protected override void setDialogueAndItemWithCondition()
    {
        PlayerBuff playerBuff = base.playerData_1.GetComponent<PlayerBuff>();
        PlayerInventory playerInventory = base.playerData_1.GetComponent<PlayerInventory>();
        if (!playerInventory.hasItem(coffeeId[0]))
        {
            if (playerBuff.GetElement(chocolateBuffId) != 99)
            {
                base.dialogue = coffee;
                base.itemId = coffeeId;
                base.gave = true;
            }
            else
            {
                base.dialogue = notBuffed;
            }
        }
        else
        {
            base.dialogue = after;
            base.itemId = null;
        }

    }
}
