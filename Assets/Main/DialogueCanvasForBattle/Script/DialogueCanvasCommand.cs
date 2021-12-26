using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;
using UnityEngine.UI;
namespace Gamekit2D
{
    public class DialogueCanvasCommand : DialogueCanvasController
    {
        [SerializeField, ReadOnly] private Button selecting;

        public void onButtonClick(Button gameObject)
        {
            if (gameObject.Equals(selecting))
            {
                Debug.Log("going great");
            }
            else
            {
                selecting = gameObject;
            }
        }
        protected override void setInputHandleBack()
        {

        }
        protected override void setInputHandle()
        {

        }
        private void Start()
        {
            
        }

        protected override void tickTask()
        {

        }

        protected override void setTextToTextMesh()
        {
            return;
        }
    }
}
