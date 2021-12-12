using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class BattleGameCanvasController : MonoBehaviour
{
    [SerializeField] private DialogueCanvasForBattleDescriptionController canvasDescription;
    [SerializeField] private DialogueCanvasCommand canvasCommand;

    public void atWaitingInput()
    {
        canvasDescription.ActivateCanvasWithDialogueArray();
        canvasCommand.ActivateCanvasWithDialogueArray();
    }

    public void atRead()
    {
        canvasDescription.ActivateCanvasWithDialogueArray();
        canvasCommand.DeactivateCanvasWithDelay(0);
    }

    public void atSelectTarget()
    {
        canvasCommand.ActivateCanvasWithDialogueArray();

        canvasDescription.ActivateCanvasWithDialogueArray();
    }

    public void atStatus()
    {
        canvasDescription.DeactivateCanvasWithDelay(0);
        canvasCommand.DeactivateCanvasWithDelay(0);
    }

  
}
