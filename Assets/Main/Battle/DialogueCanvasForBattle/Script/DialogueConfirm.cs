using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class DialogueConfirm : DialogueCanvasController
    {
        [SerializeField, ReadOnly] private GameObject target;

        public bool isConfirmed()
        {
            return true;
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

