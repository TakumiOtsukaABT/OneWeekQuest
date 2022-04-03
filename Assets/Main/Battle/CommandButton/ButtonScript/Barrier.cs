using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : BaseActionCommand
{
    [SerializeField, ReadOnly] protected GameDirector gameDirector_3;
    public GameObject dialogueCanvasCommand;


    public override void runActionCommand()
    {
        gameDirector_3 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[3].GetComponent<GameDirector>();
        gameDirector_3.resetState(BattleState.SelectTarget);
        gameDirector_3.selectingType = SelectingType.Single;
        Debug.Log("ran until");
        selectTarget();
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
        gameDirector_3.setBarrierAndDialogue();
        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect);
    }
}
