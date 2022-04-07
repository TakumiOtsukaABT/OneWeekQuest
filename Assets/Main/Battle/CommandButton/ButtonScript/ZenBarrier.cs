using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenBarrier : WazaAction
{
    protected override void whenMPIsEnough()
    {
        initialSetupObjects(SelectingType.Multiple);
        base.selectTarget();
    }

    override protected IEnumerator chooseTarget()
    {
        Debug.Log(gameDirector_3.getFlagDoneSelecting());
        yield return new WaitUntil(gameDirector_3.getFlagDoneSelecting);
        Debug.Log("ran untilwait");
        Debug.Log(gameDirector_3.getFlagDoneSelecting());
        gameDirector_3.setBarriersAndDialogue();
        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect, multiple: true);
    }
}
