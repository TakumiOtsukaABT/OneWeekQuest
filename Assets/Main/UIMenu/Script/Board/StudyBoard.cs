using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyBoard : GrowthBoard
{
    public int id;
    public override void childActivation()
    {
        base.fadeoutCharacterController.ActivateStudy();
    }

    public override void childTakeEffect()
    {
        GameObject playerData = base.CharacterHouse.GetComponent<Outlet>().gameObjects[0];
        playerData.GetComponent<PlayerStudyCommandsList>().Add(id);
    }
}
