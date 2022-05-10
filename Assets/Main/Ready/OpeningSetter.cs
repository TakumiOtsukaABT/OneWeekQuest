using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OpeningSetter : MonoBehaviour
{
    public List<string> dialogue = new List<string>();
    public DialogueCanvasController dialogueCanvas;
    // Start is called before the first frame update
    void Start()
    {
        dialogueCanvas.Dialogue = dialogue.ToArray();
        dialogueCanvas.ActivateCanvasWithDialogueArray();
    }

}
