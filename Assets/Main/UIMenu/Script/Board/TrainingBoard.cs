using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingBoard : GrowthBoard
{
     public PlayerStatusForReference incrementPlayerStatus = null;
    private bool sushi = false;

    public bool Sushi { set => sushi = value; }

    public override void childActivation()
    {
        base.fadeoutCharacterController.ActivateTrain();
    }


    public override void childTakeEffect()
    {
        GameObject playerData = base.CharacterHouse.GetComponent<Outlet>().gameObjects[0];
        if (sushi)
        {
            playerData.GetComponent<PlayerStatus>().playerStatusForReference.increment(incrementPlayerStatus, 1.5f);
            sushi = false;
        }
        else
        {
            playerData.GetComponent<PlayerStatus>().playerStatusForReference.increment(incrementPlayerStatus, 1.0f);
        }
        
        base.taskHandler_3.tickTask("Train");
    }

}
