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
        [SerializeField] private Event initialDialogue;
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

        protected override void tickTask()
        {
            //empty
        }
    }
}
