using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : WazaAction
{
    override protected IEnumerator chooseTarget()
    {
        yield return new WaitUntil(gameDirector_3.getFlagDoneSelecting);
        gameDirector_3.setBarrierAndDialogue();
        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect);
    }
}
