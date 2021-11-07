using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class MobCharacterController : MonoBehaviour
{
    public string[] dialogue;
    [SerializeField] private GameObject hukidashi;
    [SerializeField, ReadOnly] private GameObject dialogueCanvas_0;

    private void Start()
    {
        dialogueCanvas_0 = GetComponent<Outlet>().gameObjects[0];
    }

    public void activateCanvas()
    {
        var dialogueCanvas = dialogueCanvas_0.GetComponent<DialogueCanvasController>();
        dialogueCanvas.Dialogue = dialogue;
        dialogueCanvas.ActivateCanvasWithDialogueArray();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hukidashi.gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hukidashi.gameObject.SetActive(false);
    }
}
