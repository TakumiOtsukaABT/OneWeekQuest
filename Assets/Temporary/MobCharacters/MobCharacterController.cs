using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class MobCharacterController : MonoBehaviour
{
    public string[] dialogue;

    public void activateCanvas()
    {
        var dialogueCanvas = GameObject.Find("DialogueCanvas").GetComponent<DialogueCanvasController>();
        dialogueCanvas.Dialogue = dialogue;
        dialogueCanvas.ActivateCanvasWithDialogueArray();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.transform.Find("Canvas").gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.transform.Find("Canvas").gameObject.SetActive(false);
    }
}
