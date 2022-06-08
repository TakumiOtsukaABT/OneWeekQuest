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
        yield return new WaitUntil(gameDirector_3.getFlagDoneSelecting);
        gameDirector_3.setBarriersAndDialogue();
        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect, multiple: true);
    }
}
