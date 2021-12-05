using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gamekit2D
{
    public class DialogueCanvasForBattleDescriptionController : DialogueCanvasController
    {
        public string[] newDialogue;


        protected override void setInputHandle()
        {
            base.inputController_1.setInputHandle<Battle_ReadInputHandle>();
        }

        protected override void setInputHandleBack()
        {
            base.inputController_1.setInputHandle<Battle_ReadInputHandle>();
        }

        private void Start()
        {
            inputController_1 = GetComponent<Outlet>().gameObjects[1].GetComponent<InputController>();
            base.Dialogue =  newDialogue;
        }


    }
}
