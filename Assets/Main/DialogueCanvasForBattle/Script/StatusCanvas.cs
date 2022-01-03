using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusCanvas : DialogueCanvasController
{
    protected override void setInputHandleBack()
    {

    }
    protected override void setInputHandle()
    {

    }
    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ActivateCanvasWithDialogueArray();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            DeactivateCanvasWithDelay(0);
        }
    }

    protected override void tickTask()
    {

    }

    protected override void setTextToTextMesh()
    {
        return;
    }
}
