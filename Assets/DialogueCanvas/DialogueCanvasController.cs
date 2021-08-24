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
        InputController inputController;
        private string[] dialogue;
        private int dialogueIndex = 0;

        protected Coroutine m_DeactivationCoroutine;
    
        protected readonly int m_HashActivePara = Animator.StringToHash ("Active");

        public string[] Dialogue { get => dialogue; set => dialogue = value; }
        public int DialogueIndex { get => dialogueIndex; set => dialogueIndex = value; }

        private void Start()
        {
            inputController = GameObject.Find("InputController").GetComponent<InputController>();
        }

        IEnumerator SetAnimatorParameterWithDelay (float delay)
        {
            yield return new WaitForSeconds (delay);
            animator.SetBool(m_HashActivePara, false);
        }

        public void ActivateCanvasWithText (string text)
        {
            if (m_DeactivationCoroutine != null)
            {
                StopCoroutine (m_DeactivationCoroutine);
                m_DeactivationCoroutine = null;
            }

            gameObject.SetActive (true);
            animator.SetBool (m_HashActivePara, true);
            textMeshProUGUI.text = text;
            inputController.setInputHandle<TownConversationInputHandle>();

        }

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
            inputController.setInputHandle<TownConversationInputHandle>();
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
            inputController.setInputHandle<CharacterMovementInputHandle>();
            dialogueIndex = 0;
        }
    }
}
