using UnityEngine;
using Gamekit2D;

public class TownConversationInputHandle : InputHandle
{
    [SerializeField,ReadOnly] private GameObject target_1;

    private void Start()
    {
        target_1 = gameObject.GetComponent<Outlet>().gameObjects[1];
    }
    public override void handle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DialogueCanvasController dialogueCanvas = target_1.GetComponent<DialogueCanvasController>();
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
