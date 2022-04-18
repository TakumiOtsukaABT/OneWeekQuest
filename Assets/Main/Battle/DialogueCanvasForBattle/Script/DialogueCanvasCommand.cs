using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;
using UnityEngine.UI;

    public class DialogueCanvasCommand : DialogueCanvasController
    {
        [SerializeField, ReadOnly] private GameObject selecting;
        [SerializeField] private GameObject waza_panel;

        public void initializeProperty()
        {
            selecting = null;
            waza_panel.SetActive(false);
        }
        public void onButtonClick(GameObject gameObject)
        {
            if (gameObject.Equals(selecting))
            {
                selecting.GetComponent<BaseActionCommand>().runActionCommand();            }
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