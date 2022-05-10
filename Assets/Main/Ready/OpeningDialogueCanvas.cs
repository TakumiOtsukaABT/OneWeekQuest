using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDialogueCanvas : DialogueCanvasController
{
    public GameObject inputField;
    protected override void setInputHandleBack()
    {
        //inputController_1.setInputHandle<CharacterMovementInputHandle>();
        inputField.SetActive(true);
        inputController_1.setInputHandle<MenuInputHandle>();
    }

    protected override void tickTask()
    {
        //base.tickTask();
    }
}
