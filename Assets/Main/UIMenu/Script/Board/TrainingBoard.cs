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

    public override void childDeactivation()
    {
        base.childDeactivation();
        base.CharacterHouse.GetComponent<MenuCanvas>().popWindow();
    }

    public override void childTakeEffect()
    {
        GameObject playerData = base.CharacterHouse.GetComponent<Outlet>().gameObjects[0];
        playerData.GetComponent<PlayerStatus>().playerStatusForReference.increment(incrementPlayerStatus);
    }

}
