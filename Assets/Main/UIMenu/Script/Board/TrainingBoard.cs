using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingBoard : GrowthBoard
{
     public PlayerStatusForReference incrementPlayerStatus = null;

    public override void childActivation()
    {
        base.fadeoutCharacterController.ActivateTrain();
    }


    public override void childTakeEffect()
    {
        GameObject playerData = base.CharacterHouse.GetComponent<Outlet>().gameObjects[0];
        playerData.GetComponent<PlayerStatus>().playerStatusForReference.increment(incrementPlayerStatus);
        base.taskHandler_3.tickTask("Train");
    }

}
