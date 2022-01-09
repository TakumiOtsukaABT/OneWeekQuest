using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatBoard : GrowthBoard
{
    public int id;
    [SerializeField] TrainingBoard trainingBoard;
    [SerializeField] AlertScript alertScript;
    [SerializeField] EatReference eatReference;
    public override void childActivation()
    {
        base.fadeoutCharacterController.ActivateEat();
    }

    public override void childTakeEffect()
    {
        base.taskHandler_3.tickTask("Eat");
        effectsPerId(id);
    }

    private void effectsPerId(int id)
    {
        GameObject playerData = base.CharacterHouse.GetComponent<Outlet>().gameObjects[0];
        switch (id)
        {
            case 0:
                PlayerStatusForReference add_playerStatus = new PlayerStatusForReference();
                add_playerStatus.HP_access = 100;
                playerData.GetComponent<PlayerStatus>().playerStatusForReference.increment(add_playerStatus,1.0f);
                break;
            case 1:
                playerData.GetComponent<PlayerBuff>().buff_list.Add(id);
                break;
            case 2:
                playerData.GetComponent<PlayerBuff>().buff_list.Add(id);
                break;
            case 3:
                BaseTask _task;
                if (base.taskHandler_3.getBaseTaskByKey("Study") != null)
                {
                    _task = base.taskHandler_3.getBaseTaskByKey("Study");
                    _task.currentCondition["Study"]--;//set study to index 0 ALWAYS
                    _task.clearFlag = false;
                }
                break;
            case 4:
                trainingBoard.Sushi = true;
                break;
            case 5:
                PlayerStatusForReference add_playerStatus5 = new PlayerStatusForReference();
                add_playerStatus5.HP_access = 10;
                add_playerStatus5.MP_access = 10;
                add_playerStatus5.Attack_access = 10;
                add_playerStatus5.Defence_access = 10;
                add_playerStatus5.Speed_access = 10;
                add_playerStatus5.HitRate_access = 10;
                add_playerStatus5.Regen_access = 10;
                playerData.GetComponent<PlayerStatus>().playerStatusForReference.increment(add_playerStatus5, 1.0f);
                playerData.GetComponent<PlayerInventory>().Add(1);
                break;
        }
        alertScript.Activate(eatReference.GetElement(id).alertDialogue);
    }
}