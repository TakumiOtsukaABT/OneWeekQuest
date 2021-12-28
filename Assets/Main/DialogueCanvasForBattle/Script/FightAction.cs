using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightAction : BaseActionCommand
{
    public override void runActionCommand()
    {
        GameObject.Find("GameDirector").GetComponent<GameDirector>().resetState(BattleState.SelectTarget);
    }
}
