using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class AlertScript : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI textMeshProUGUI;
    [SerializeField, ReadOnly] protected InputController inputController_1;
    [SerializeField, ReadOnly] private TaskHandler taskHandler_0;

    protected Coroutine m_DeactivationCoroutine;

    protected readonly int m_HashActivePara = Animator.StringToHash("Active");

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Activate("lalala");
        }
    }

    IEnumerator SetAnimatorParameterWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool(m_HashActivePara, false);
    }

    public void Activate(string text)
    {
        if (m_DeactivationCoroutine != null)
        {
            StopCoroutine(m_DeactivationCoroutine);
            m_DeactivationCoroutine = null;
        }
        gameObject.SetActive(true);
        animator.SetBool(m_HashActivePara, true);
        textMeshProUGUI.text = text;
    }

    public virtual void DeactivateCanvasWithDelay(float delay)
    {
        m_DeactivationCoroutine = StartCoroutine(SetAnimatorParameterWithDelay(delay));
    }
}
