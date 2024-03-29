﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine;

namespace Gamekit2D
{
    public class DialogueCanvasForBattleDescriptionController : DialogueCanvasController
    {
        public string[] newDialogue;
        public BattleState nextState;
        public string playerName;
        public string noMPDialogue;
        [SerializeField] private Event initialDialogue;
        [SerializeField] private Event whatToDoDialogue;

        protected override void setInputHandle()
        {
            //base.inputController_1.setInputHandle<Battle_ReadInputHandle>();
        }

        protected override void setInputHandleBack()
        {
            //base.inputController_1.setInputHandle<Battle_ReadInputHandle>();
        }

        public void setNoMPDescription()
        {
            base.DialogueIndex = 0;
            string[] choose = new string[2];
            choose[0] = noMPDialogue;
            base.Dialogue = choose;
            base.setTextToTextMesh();
        }

        public void chooseTargetDialogue()
        {
            base.DialogueIndex = 0;
            string[] choose = new string[2];
            choose[0] = "対象をタップ";
            base.Dialogue = choose;
            base.setTextToTextMesh();
        }
        public void updateSingleTargetDialogue(characterType characterType)
        {
            base.DialogueIndex = 0;
            string[] choose = new string[2];
            choose[0] = getCharacterName(characterType);
            base.Dialogue = choose;
            base.setTextToTextMesh();
        }

        public void updateMultipleTargetDialogue(characterType[] characterType)
        {
            base.DialogueIndex = 0;
            string[] choose = new string[2];
            foreach(var i in characterType)
            {
                choose[0] = choose[0] +" "+ getCharacterName(i);
            }
            base.Dialogue = choose;
            base.setTextToTextMesh();
        }

        private void Start()
        {
            inputController_1 = GetComponent<Outlet>().gameObjects[1].GetComponent<InputController>();
            runInitialDialogue();
        }

        public void runInitialDialogue()
        {
            base.Dialogue = initialDialogue.dialogue;
            nextState = initialDialogue.nextState;
            ActivateCanvasWithDialogueArray();
            base.DialogueIndex = 0;
        }

        public void setNoAliveDescription(characterType characterType)
        {
            base.DialogueIndex = 0;
            string[] choose = new string[2];
            choose[0] = getCharacterName(characterType)+"は戦闘不能だ!";
            base.Dialogue = choose;
            base.setTextToTextMesh();
        }

        public void setEvent(Event new_event)
        {
            new_event.dialogue[0] = new_event.dialogue[0];
            base.Dialogue = new_event.dialogue;
            nextState = new_event.nextState;
            base.DialogueIndex = 0;
        }

        public void addEvent(Event new_event)
        {
            new_event.dialogue[0] = new_event.dialogue[0];
            List<string> unko = base.Dialogue.ToList<string>();
            unko.RemoveAt(base.Dialogue.Length-1);
            foreach (var i in new_event.dialogue)
            {
                unko.Add(i);
            }
            base.Dialogue = unko.ToArray();
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
