using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatBoard : GrowthBoard
{
    public int id;
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
                break;
            case 5:
                break;
        }
    }
}