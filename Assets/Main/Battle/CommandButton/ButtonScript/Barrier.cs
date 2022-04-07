using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : WazaAction
{
    override protected IEnumerator chooseTarget()
    {
        Debug.Log(gameDirector_3.getFlagDoneSelecting());
        yield return new WaitUntil(gameDirector_3.getFlagDoneSelecting);
        Debug.Log("ran untilwait");
        Debug.Log(gameDirector_3.getFlagDoneSelecting());
        gameDirector_3.setBarrierAndDialogue();
        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect);
    }
}
