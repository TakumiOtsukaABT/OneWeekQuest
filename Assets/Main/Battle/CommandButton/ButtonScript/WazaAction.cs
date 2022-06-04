using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WazaAction : BaseActionCommand
{
    [SerializeField, ReadOnly] protected GameDirector gameDirector_3;
    public GameObject dialogueCanvasCommand;
    public int cost;

    public override void runActionCommand()
    {
        if (isMPEnough())
        {
            gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().setMP(
                gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().playerStatusForReference.MP_access - cost);
            whenMPIsEnough();
        } else
        {
            whenMPIsNotEnough();
        }
    }

    protected virtual void whenMPIsEnough()
    {
        initialSetupObjects(SelectingType.Single);
        selectTarget();
    }

    protected virtual void whenMPIsNotEnough()
    {
        gameDirector_3.setNoMPDialogue();
    }


    protected bool isMPEnough()
    {
        gameDirector_3 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[3].GetComponent<GameDirector>();
        return cost < gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().playerStatusForReference.MP_access;
    }

    protected void initialSetupObjects(SelectingType selecting)
    {
        gameDirector_3 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[3].GetComponent<GameDirector>();
        gameDirector_3.resetState(BattleState.SelectTarget);
        gameDirector_3.selectingType = selecting;
    }
    protected void selectTarget()
    {
        StartCoroutine(chooseTarget());
    }

    protected virtual IEnumerator chooseTarget()
    {
        yield return new WaitUntil(gameDirector_3.getFlagDoneSelecting);
    }

}
