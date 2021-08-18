using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutController : MonoBehaviour
{
    public Animator animator;
    protected Coroutine m_DeactivationCoroutine;

    protected readonly int m_HashActivePara = Animator.StringToHash("Active");

    IEnumerator SetAnimatorParameterWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool(m_HashActivePara, false);
    }

    public void ActivateBlackout()
    {
        if (m_DeactivationCoroutine != null)
        {
            StopCoroutine(m_DeactivationCoroutine);
            m_DeactivationCoroutine = null;
        }
        gameObject.SetActive(true);
        animator.SetBool(m_HashActivePara, true);
    }

    public void DeactivateCanvasWithDelay(float delay)
    {
        m_DeactivationCoroutine = StartCoroutine(SetAnimatorParameterWithDelay(delay));
    }
}
