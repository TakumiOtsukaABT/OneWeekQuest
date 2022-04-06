using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveAction : WazaAction
{
    [SerializeField] float editMultiplier;
    public override void runActionCommand()
    {
        if (isMPEnough())
        {
            gameDirector_3 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[3].GetComponent<GameDirector>();
            gameDirector_3.resetState(BattleState.SelectTarget);
            gameDirector_3.selectingType = SelectingType.Single;
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
        int regen = gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().playerStatusForReference.Regen_access;
        gameDirector_3.setReviveAndDialogue();
        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect);
    }
}
