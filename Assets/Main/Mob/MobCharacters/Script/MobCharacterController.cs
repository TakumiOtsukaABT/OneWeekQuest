using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class MobCharacterController : MonoBehaviour
{
    public string[] dialogue;
    [SerializeField,ReadOnly] private GameObject hukidashi_0;
    [SerializeField, ReadOnly] private GameObject dialogueCanvas_1;

    private void Start()
    {
        hukidashi_0 = GetComponent<Outlet>().gameObjects[0];
        dialogueCanvas_1 = GetComponent<Outlet>().gameObjects[1];
    }

    public void activateCanvas()
    {
        var dialogueCanvas = dialogueCanvas_1.GetComponent<DialogueCanvasController>();
        dialogueCanvas.Dialogue = dialogue;
        dialogueCanvas.ActivateCanvasWithDialogueArray();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hukidashi_0.gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hukidashi_0.gameObject.SetActive(false);
    }
}
