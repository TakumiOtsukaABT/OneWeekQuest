using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    [SerializeField] GameObject menuWindow;
    // Start is called before the first frame update
    void OnEnable()
    {
        menuWindow.GetComponent<Animator>().SetBool("isActive", true);
    }

    private void OnDisable()
    {
        menuWindow.GetComponent<Animator>().SetBool("isActive", false);
        //DeactivateCanvasWithDelay(1);
    }

    IEnumerator SetAnimatorParameterWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    public void DeactivateCanvasWithDelay(float delay)
    {
        StartCoroutine(SetAnimatorParameterWithDelay(delay));
    }
}
