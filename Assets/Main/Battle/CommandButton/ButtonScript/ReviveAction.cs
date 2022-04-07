using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveAction : WazaAction
{
    [SerializeField] float editMultiplier;

    override protected IEnumerator chooseTarget()
    {
        Debug.Log(gameDirector_3.getFlagDoneSelecting());
        gameDirector_3.IsReviveCalling = true;
        yield return new WaitUntil(gameDirector_3.getFlagDoneSelecting);
        Debug.Log("ran untilwait");
        Debug.Log(gameDirector_3.getFlagDoneSelecting());
        int regen = gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().playerStatusForReference.Regen_access;
        gameDirector_3.IsReviveCalling = false;
        gameDirector_3.setReviveAndDialogue();
        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect);
    }
}
