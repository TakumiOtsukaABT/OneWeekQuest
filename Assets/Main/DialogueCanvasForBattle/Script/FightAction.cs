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

    public override void runActionCommand()
    {
        GameObject.Find("GameDirector").GetComponent<GameDirector>().resetState(BattleState.SelectTarget);
        battleGameCanvasController_3 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[3].GetComponent<BattleGameCanvasController>();
        battleGameCanvasController_3.selectingType = SelectingType.Single;
    }

    private void selectTarget()
    {
        dialoguecanvasConfirm_2 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[2].GetComponent<DialogueConfirm>();
        StartCoroutine(chooseTarget());
    }
    IEnumerator chooseTarget()
    {
        throw new UnassignedReferenceException();
    }
}
