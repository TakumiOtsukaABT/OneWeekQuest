using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;
using UnityEngine.UI;
namespace Gamekit2D
{
    public class DialogueCanvasCommand : DialogueCanvasController
    {
        [SerializeField, ReadOnly] private GameObject selecting;

        void initializeProperty()
        {
            selecting = null;
        }
        public void onButtonClick(GameObject gameObject)
        {
            if (gameObject.Equals(selecting))
            {
                selecting.GetComponent<BaseActionCommand>().runActionCommand();
                initializeProperty();
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
