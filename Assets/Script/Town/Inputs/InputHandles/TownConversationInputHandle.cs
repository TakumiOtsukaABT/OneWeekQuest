using UnityEngine;
using Gamekit2D;

public class TownConversationInputHandle : InputHandle
{
    public GameObject target;
    public override void handle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DialogueCanvasController dialogueCanvas = target.GetComponent<DialogueCanvasController>();
            dialogueCanvas.DialogueIndex++;
            dialogueCanvas.ActivateCanvasWithDialogueArray();
            if (dialogueCanvas.isLastDialogue())
            {
                dialogueCanvas.DeactivateCanvasWithDelay(0);
                return;
            }
        }
    }
}
