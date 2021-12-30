using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class FightAction : BaseActionCommand
{
    [SerializeField,ReadOnly] private GameObject targetCharacter;
    [SerializeField,ReadOnly] private DialogueConfirm dialoguecanvasConfirm_2;
    [SerializeField, ReadOnly] private BattleGameCanvasController battleGameCanvasController_3;
    [SerializeField] private GameObject dialogueCanvasCommand;
    [SerializeField, ReadOnly] private GameObject target;
    public GameDirector gameDirector;

    public override void runActionCommand()
    {
        gameDirector.resetState(BattleState.SelectTarget);
        battleGameCanvasController_3 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[3].GetComponent<BattleGameCanvasController>();
        battleGameCanvasController_3.selectingType = SelectingType.Single;
        selectTarget();
    }

    private void selectTarget()
    {
        StartCoroutine(chooseTarget());
    }
    IEnumerator chooseTarget()
    {
        dialoguecanvasConfirm_2 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[2].GetComponent<DialogueConfirm>();
        yield return new WaitUntil(battleGameCanvasController_3.getFlagDoneSelecting);
        target = battleGameCanvasController_3.Single_target;
        gameDirector.resetState(BattleState.Read);

    }
}
