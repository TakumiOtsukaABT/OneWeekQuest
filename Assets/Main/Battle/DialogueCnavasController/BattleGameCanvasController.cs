using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class BattleGameCanvasController : MonoBehaviour
{
    [SerializeField] private DialogueCanvasForBattleDescriptionController canvasDescription;
    [SerializeField] private DialogueCanvasCommand canvasCommand;
    [SerializeField] private DialogueConfirm canvasConfirm;
    [SerializeField, ReadOnly] private List<GameObject> targetted = new List<GameObject>();
    [SerializeField, ReadOnly] private GameObject single_target;
    private bool selected = false;

    [ReadOnly]public SelectingType selectingType = SelectingType.Disable;

    public GameObject Single_target { get => single_target; set => single_target = value; }

    public void atWaitingInput(characterType characterType)
    {
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
        selected = false;
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
        selectingType = SelectingType.Disable;
        canvasDescription.DeactivateCanvasWithDelay(0);
        canvasCommand.DeactivateCanvasWithDelay(0);
        canvasConfirm.DeactivateCanvasWithDelay(0);
    }

    public void setClickedObject(GameObject gameObject)
    {
        switch (selectingType)
        {
            case SelectingType.Single:
                Single_target = gameObject;
                canvasDescription.updateSingleTargetDialogue(Single_target.GetComponent<StatusBattle>().characterType);
                break;
            case SelectingType.Multiple:
                for (int i = 0; i < targetted.Count; i++)
                {
                    if (gameObject.Equals(targetted[i]))
                    {
                        targetted.Remove(gameObject);
                        return;
                    }
                }
                targetted.Add(gameObject);
                break;
            case SelectingType.Disable:
                break;
        }
        return;
    }

    public void setSelectedFlag()
    {
        selected = true;
    }

    public void setDescriptionByEvent(Event _event)
    {
        canvasDescription.setEvent(_event);
    }

    public bool getFlagDoneSelecting()
    {
        if (Single_target != null || targetted != null)
        {
            return selected;
        }
        else { return false; }
    }

}

public enum SelectingType
{
    Single,
    Multiple,
    Disable
}