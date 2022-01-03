using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusCanvas : DialogueCanvasController
{
    [SerializeField] private StatDataBattle statDataBattle;
    private bool closed = false;

    public new void ActivateCanvasWithDialogueArray()
    {
        closed = false;
        base.ActivateCanvasWithDialogueArray();
    }

    public void DeactivateCanvasWithDelay()
    {
        closed = true;
        base.DeactivateCanvasWithDelay(0);
    }

    public bool isClosed()
    {
        return closed;
    }

    public void setstatDataBattle(PlayerStatusForReference new_stat)
    {
        statDataBattle.character = new_stat;
    }
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
