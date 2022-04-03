using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class BattleGameCanvasController : MonoBehaviour
{
    [SerializeField] private DialogueCanvasForBattleDescriptionController canvasDescription;
    [SerializeField] private DialogueCanvasCommand canvasCommand;
    [SerializeField] private DialogueConfirm canvasConfirm;

    public void atWaitingInput(characterType characterType)
    {
        canvasCommand.initializeProperty();
        canvasDescription.waitingInputTurn(characterType);
        canvasDescription.ActivateCanvasWithDialogueArray();
        canvasCommand.ActivateCanvasWithDialogueArray();
        canvasConfirm.DeactivateCanvasWithDelay(0);
    }

    public void atRead()
    {
        canvasDescription.ActivateCanvasWithDialogueArray();
        canvasCommand.DeactivateCanvasWithDelay(0);
        canvasConfirm.DeactivateCanvasWithDelay(0);
    }

    public void atSelectTarget()
    {
        canvasDescription.chooseTargetDialogue();
        canvasCommand.DeactivateCanvasWithDelay(0);
        canvasConfirm.ActivateCanvasWithDialogueArray();
        canvasDescription.ActivateCanvasWithDialogueArray();
    }

    public void atStatus()
    {
        canvasDescription.DeactivateCanvasWithDelay(0);
        canvasCommand.DeactivateCanvasWithDelay(0);
        canvasConfirm.DeactivateCanvasWithDelay(0);
    }

    public void deactivateAll() {
        canvasDescription.DeactivateCanvasWithDelay(0);
        canvasCommand.DeactivateCanvasWithDelay(0);
        canvasConfirm.DeactivateCanvasWithDelay(0);
    }

    public void setDescriptionByEvent(Event _event)
    {
        canvasDescription.setEvent(_event);
    }

    public void updateDescription_singleTarget(characterType characterType)
    {
        canvasDescription.updateSingleTargetDialogue(characterType);
    }

    public void updateDescription_multipleTarget(characterType[] characterType)
    {
        canvasDescription.updateMultipleTargetDialogue(characterType);
    }
}

public enum SelectingType
{
    Single,
    Multiple,
    Disable
}