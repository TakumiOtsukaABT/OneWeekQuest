using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;


public class Battle_ReadInputHandle : InputHandle
{
    [SerializeField, ReadOnly] private GameObject dialogueCanvas_1;
    [SerializeField, ReadOnly] private GameDirector gameDirector_2;


    private void Start()
    {
        dialogueCanvas_1 = gameObject.GetComponent<Outlet>().gameObjects[1];
        gameDirector_2 = gameObject.GetComponent<Outlet>().gameObjects[2].GetComponent<GameDirector>();
    }
    public override void handle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DialogueCanvasForBattleDescriptionController dialogueCanvas = dialogueCanvas_1.GetComponent<DialogueCanvasForBattleDescriptionController>();
            dialogueCanvas.DialogueIndex++;
            dialogueCanvas.ActivateCanvasWithDialogueArray();
            Debug.Log("islasaaat"+dialogueCanvas.DialogueIndex);

            if (dialogueCanvas.isLastDialogue())
            {
                Debug.Log("islast");
                gameDirector_2.resetState(dialogueCanvas.nextState);
                return;
            }
        }
    }
}
