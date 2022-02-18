﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class MobCharacterController : MonoBehaviour
{
    public string[] dialogue;
    public int[] itemId;
    [SerializeField] private GameObject hukidashi;
    [SerializeField, ReadOnly] private GameObject dialogueCanvas_0;
    [SerializeField, ReadOnly] private GameObject playerData_1;
    [SerializeField, ReadOnly] private TaskHandler taskHandler_2;



    private void Start()
    {
        dialogueCanvas_0 = GetComponent<Outlet>().gameObjects[0];
        taskHandler_2 = GetComponent<Outlet>().gameObjects[2].GetComponent<TaskHandler>();
    }

    public void activateCanvas()
    {
        playerData_1 = GetComponent<Outlet>().gameObjects[1];
        var dialogueCanvas = dialogueCanvas_0.GetComponent<DialogueCanvasController>();
        dialogueCanvas.Dialogue = dialogue;
        dialogueCanvas.ActivateCanvasWithDialogueArray();
        addToInventory();
    }

    private void addToInventory()
    {
        var inventory = playerData_1.GetComponent<PlayerInventory>();
        if (itemId.Length != 0)
        {
            foreach (var i in itemId)
            {
                inventory.Add(i);
            }
            taskHandler_2.tickTask("ReceiveFromPeople");
        }
        else
        {
            return;
        }
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
