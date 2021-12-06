using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;


public class Battle_ReadInputHandle : InputHandle
{
    [SerializeField, ReadOnly] private GameObject dialogueCanvas_1;

    private void Start()
    {
        dialogueCanvas_1 = gameObject.GetComponent<Outlet>().gameObjects[1];
    }
    public override void handle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DialogueCanvasForBattleDescriptionController dialogueCanvas = dialogueCanvas_1.GetComponent<DialogueCanvasForBattleDescriptionController>();
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
