using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gamekit2D
{
    public class DialogueCanvasForBattleDescriptionController : DialogueCanvasController
    {
        public string[] newDialogue;
        public BattleState nextState;
        public string playerName;
        [SerializeField] private Event initialDialogue;
        [SerializeField] private Event whatToDoDialogue;
        [SerializeField,ReadOnly] private GameDirector director_2;

        protected override void setInputHandle()
        {
            //base.inputController_1.setInputHandle<Battle_ReadInputHandle>();
        }

        protected override void setInputHandleBack()
        {
            //base.inputController_1.setInputHandle<Battle_ReadInputHandle>();
        }

        private void Start()
        {
            inputController_1 = GetComponent<Outlet>().gameObjects[1].GetComponent<InputController>();
            director_2 = GetComponent<Outlet>().gameObjects[2].GetComponent<GameDirector>();
            runInitialDialogue();
        }

        public void runInitialDialogue()
        {
            base.Dialogue = initialDialogue.dialogue;
            nextState = initialDialogue.nextState;
            ActivateCanvasWithDialogueArray();
            base.DialogueIndex = 0;
        }

        public void waitingInputTurn(characterType character)
        {
            base.DialogueIndex = 0;
            string[] whatTodo = new string[2];
            string characterName = getCharacterName(character);
            whatTodo[0] = characterName + whatToDoDialogue.dialogue[0];
            base.Dialogue = whatTodo;
        }

        private string getCharacterName(characterType character)
        {
            switch (character)
            {
                case characterType.Human:
                    return playerName;
                    break;
                case characterType.Dog:
                    return "犬";
                    break;
                case characterType.Cat:
                    return "猫";
                    break;
                case characterType.Alpaca:
                    return "アルパカ";
                    break;
                case characterType.Enemy:
                    return "";
                    break;
                default:
                    return "";
                    break;
            }
        }

        protected override void tickTask()
        {
            //empty
        }
    }
}
