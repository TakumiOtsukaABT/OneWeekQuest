using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusAction : BaseActionCommand
{
    [SerializeField, ReadOnly] private GameDirector gameDirector_3;
    public GameObject dialogueCanvasCommand;
    public StatusCanvas statusCanvas;


    public override void runActionCommand()
    {
        gameDirector_3 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[3].GetComponent<GameDirector>();
        gameDirector_3.resetState(BattleState.SelectTarget);
        gameDirector_3.selectingType = SelectingType.Single;
        selectTarget();
    }

    private void selectTarget()
    {
        StartCoroutine(chooseTarget());
    }
    IEnumerator chooseTarget()
    {
        yield return new WaitUntil(gameDirector_3.getFlagDoneSelecting);
        StatusBattle targetPlayer = gameDirector_3.Single_target.GetComponent<StatusBattle>();
        gameDirector_3.deactivateAllCanvas();
        statusCanvas.setstatDataBattle(targetPlayer);
        statusCanvas.ActivateCanvasWithDialogueArray();
        yield return new WaitUntil(statusCanvas.isClosed);
        gameDirector_3.resetState(BattleState.WaitingInput, false);
    }
}
