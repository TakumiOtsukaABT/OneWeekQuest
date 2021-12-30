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

        public void chooseTargetDialogue()
        {
            base.DialogueIndex = 0;
            string[] choose = new string[2];
            choose[0] = "対象をタップ";
            base.Dialogue = choose;
        }
        public void updateSingleTargetDialogue(characterType characterType)
        {
            base.DialogueIndex = 0;
            string[] choose = new string[2];
            choose[0] = getCharacterName(characterType);
            base.Dialogue = choose;
            base.setTextToTextMesh();
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

        public void setEvent(Event new_event)
        {
            new_event.dialogue[0] = playerName + new_event.dialogue[0];
            base.Dialogue = new_event.dialogue;
            nextState = new_event.nextState;
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
                case characterType.Dog:
                    return "犬";
                case characterType.Cat:
                    return "猫";
                case characterType.Alpaca:
                    return "アルパカ";
                case characterType.Enemy:
                    return "魔王";
                default:
                    return "";
            }
        }

        protected override void tickTask()
        {
            //empty
        }
    }
}
