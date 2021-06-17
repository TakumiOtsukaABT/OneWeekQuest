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
            //dialogueCanvas.DeactivateCanvasWithDelay(0);
        }
    }
}
