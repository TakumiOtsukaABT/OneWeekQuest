using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class AlertScript : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private float seconds;
    protected Coroutine m_DeactivationCoroutine;

    protected readonly int m_HashActivePara = Animator.StringToHash("Active");

    IEnumerator SetAnimatorParameterWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool(m_HashActivePara, false);
    }

    public void Activate(string text)
    {
        StartCoroutine(waitFadeout(text,seconds));
    }

    public void Activate(string text, float sec)
    {
        StartCoroutine(waitFadeout(text, sec));
    }

    IEnumerator waitFadeout(string text,float seconds)
    {
        yield return new WaitForSeconds(seconds);
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
