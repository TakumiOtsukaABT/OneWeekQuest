using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutController : MonoBehaviour
{
    public Animator animator;
    protected Coroutine m_DeactivationCoroutine;

    protected readonly int m_HashActivePara = Animator.StringToHash("Active");
    //0stale 1blackout 2blackoutend 3fadeout 4fadeoutend


    private void Start()
    {
        Debug.Log("aaaa");
        DeactivateFadeoutWithDelay(0);
    }
    IEnumerator SetAnimatorParameterWithDelay(float delay, int state)
    {
        yield return new WaitForSeconds(delay);
        animator.SetInteger(m_HashActivePara, state);
    }

    public void ActivateBlackout()
    {
        if (m_DeactivationCoroutine != null)
        {
            StopCoroutine(m_DeactivationCoroutine);
            m_DeactivationCoroutine = null;
        }
        gameObject.SetActive(true);
        animator.SetInteger(m_HashActivePara, 1);
    }
    public void ActivateFadeout()
    {
        if (m_DeactivationCoroutine != null)
        {
            StopCoroutine(m_DeactivationCoroutine);
            m_DeactivationCoroutine = null;
        }
        gameObject.SetActive(true);
        animator.SetInteger(m_HashActivePara, 3);
    }

    public void DeactivateBlackoutWithDelay(float delay)
    {
        m_DeactivationCoroutine = StartCoroutine(SetAnimatorParameterWithDelay(delay,2));
    }

    public void DeactivateFadeoutWithDelay(float delay)
    {
        m_DeactivationCoroutine = StartCoroutine(SetAnimatorParameterWithDelay(delay, 4));
    }
}
