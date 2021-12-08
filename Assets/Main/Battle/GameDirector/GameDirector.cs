using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class GameDirector : MonoBehaviour
{
    [SerializeField, ReadOnly] private BattleState battleState = BattleState.Read;
    [SerializeField, ReadOnly] private InputController inputController_2;
    [SerializeField, ReadOnly] private DialogueCanvasForBattleDescriptionController dialogueCanvasDescription_0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Outlet>().gameObjects[0].GetComponent<DialogueCanvasForBattleDescriptionController>().runInitialDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setState(BattleState newState)
    {
        battleState = newState;
        switch (newState)
        {
            case BattleState.WaitingInput:
                inputController_2.setInputHandle<Battle_CommandInputHandle>();
                break;
            case BattleState.Read:
                inputController_2.setInputHandle<Battle_ReadInputHandle>();
                break;
            case BattleState.SelectTarget:
                inputController_2.setInputHandle<Battle_CommandInputHandle>();
                break;
            case BattleState.Status:
                inputController_2.setInputHandle<Battle_CommandInputHandle>();
                break;
        }
    }
}
