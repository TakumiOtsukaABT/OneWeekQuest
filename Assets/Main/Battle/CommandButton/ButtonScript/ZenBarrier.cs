using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenBarrier : WazaAction
{

    public override void runActionCommand()
    {
        if (isMPEnough())
        {
            gameDirector_3 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[3].GetComponent<GameDirector>();
            gameDirector_3.resetState(BattleState.SelectTarget);
            gameDirector_3.selectingType = SelectingType.Multiple;
            Debug.Log("ran until");
            selectTarget();
        }
    }

    private void selectTarget()
    {
        StartCoroutine(chooseTarget());
    }
    virtual protected IEnumerator chooseTarget()
    {
        Debug.Log(gameDirector_3.getFlagDoneSelecting());
        yield return new WaitUntil(gameDirector_3.getFlagDoneSelecting);
        Debug.Log("ran untilwait");
        Debug.Log(gameDirector_3.getFlagDoneSelecting());
        gameDirector_3.setBarriersAndDialogue();
        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect, multiple: true);
    }
}
