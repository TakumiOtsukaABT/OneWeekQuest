using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeoutCharacterController : MonoBehaviour
{
    public Animator animator;
    protected Coroutine m_DeactivationCoroutine;

    protected readonly int m_HashActivePara = Animator.StringToHash("Active");
    //0stale 1train 2study 3sleep 4Eat

    public void ActivateTrain()
    {
        if (m_DeactivationCoroutine != null)
        {
            StopCoroutine(m_DeactivationCoroutine);
            m_DeactivationCoroutine = null;
        }
        gameObject.SetActive(true);
        animator.SetInteger(m_HashActivePara, 1);
    }

    public void DeactivateWithDelay(float delay)
    {
        m_DeactivationCoroutine = StartCoroutine(SetAnimatorParameterWithDelay(delay, 0));
    }

    IEnumerator SetAnimatorParameterWithDelay(float delay, int state)
    {
        yield return new WaitForSeconds(delay);
        animator.SetInteger(m_HashActivePara, state);
    }
}
