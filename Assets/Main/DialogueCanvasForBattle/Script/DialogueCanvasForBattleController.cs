using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gamekit2D
{
    public class DialogueCanvasController : MonoBehaviour
    {
        public Animator animator;
        public TextMeshProUGUI textMeshProUGUI;
        [SerializeField, ReadOnly] private InputController inputController_1;
        [SerializeField,ReadOnly] private TaskHandler taskHandler_0;
        private string[] dialogue;
        private int dialogueIndex = 0;

        protected Coroutine m_DeactivationCoroutine;
    
        protected readonly int m_HashActivePara = Animator.StringToHash ("Active");

        public string[] Dialogue { get => dialogue; set => dialogue = value; }
        public int DialogueIndex { get => dialogueIndex; set => dialogueIndex = value; }

        private void Start()
        {
            taskHandler_0 = GetComponent<Outlet>().gameObjects[0].GetComponent<TaskHandler>();
            inputController_1 = GetComponent<Outlet>().gameObjects[1].GetComponent<InputController>();
        }

        IEnumerator SetAnimatorParameterWithDelay (float delay)
        {
            yield return new WaitForSeconds (delay);
            animator.SetBool(m_HashActivePara, false);
        }

        //public void ActivateCanvasWithText (string text)
        //{
        //    if (m_DeactivationCoroutine != null)
        //    {
        //        StopCoroutine (m_DeactivationCoroutine);
        //        m_DeactivationCoroutine = null;
        //    }

        //    gameObject.SetActive (true);
        //    animator.SetBool (m_HashActivePara, true);
        //    textMeshProUGUI.text = text;
        //    inputController.setInputHandle<TownConversationInputHandle>();

        //}

        public void ActivateCanvasWithDialogueArray()
        {
            if (m_DeactivationCoroutine != null)
            {
                StopCoroutine(m_DeactivationCoroutine);
                m_DeactivationCoroutine = null;
            }
            gameObject.SetActive(true);
            animator.SetBool(m_HashActivePara, true);
            textMeshProUGUI.text = dialogue[dialogueIndex];
            inputController_1.setInputHandle<TownConversationInputHandle>();
        }

        public bool isLastDialogue()
        {
            return dialogue[dialogueIndex] == "";
        }

        //public void ActivateCanvasWithTranslatedText (string phraseKey)
        //{
        //    if (m_DeactivationCoroutine != null)
        //    {
        //        StopCoroutine(m_DeactivationCoroutine);
        //        m_DeactivationCoroutine = null;
        //    }

        //    gameObject.SetActive(true);
        //    animator.SetBool(m_HashActivePara, true);
        //    //textMeshProUGUI.text = Translator.Instance[phraseKey];
        //}

        public void DeactivateCanvasWithDelay (float delay)
        {
            m_DeactivationCoroutine = StartCoroutine (SetAnimatorParameterWithDelay (delay));
            inputController_1.setInputHandle<CharacterMovementInputHandle>();
            dialogueIndex = 0;
            taskHandler_0.tickTask("Talk");
        }
    }
}
