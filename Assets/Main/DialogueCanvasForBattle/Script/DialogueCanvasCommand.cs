using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;
namespace Gamekit2D
{
    public class DialogueCanvasCommand : DialogueCanvasController
    {


        protected override void setInputHandleBack()
        {
            base.inputController_1.setInputHandle<Battle_ReadInputHandle>();
        }
    }
}
