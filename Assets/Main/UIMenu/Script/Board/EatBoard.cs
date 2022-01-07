using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatBoard :GrowthBoard
{
    public int id;
    public override void childActivation()
    {
        base.fadeoutCharacterController.ActivateEat();
    }

    public override void childTakeEffect()
    {
        GameObject playerData = base.CharacterHouse.GetComponent<Outlet>().gameObjects[0];
        playerData.GetComponent<PlayerBuff>().buff_list.Add(id);
        base.taskHandler_3.tickTask("Eat");
    }

}
