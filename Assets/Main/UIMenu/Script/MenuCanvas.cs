using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    public Stack<GameObject> menuStack = new Stack<GameObject>() { };
    [SerializeField] InputController inputController;
    [SerializeField] GameObject firstButton;
    [SerializeField] GameObject secondButton;


    public void Start()
    {
        firstButton.SetActive(true);
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("UIPanels"))
        {
            i.SetActive(false);
        }
        pushWindow(firstButton);
    }

    public void pushWindow(GameObject window)
    {
        window.SetActive(true);
        menuStack.Push(window);
    }

    public void popWindow(bool ignoreEmpty=false)
    {
        var window = menuStack.Pop();
        if (menuStack.Count == 0)
        {
            if (!ignoreEmpty)
            {
                DeactivateCanvasWithDelay(window);
            }
            else
            {
                window.SetActive(false);
            }
        }
        else
        {
            DeactivateCanvasWithDelayForLaterPanel(window);
        }
    }
    public void popWindowForCharacterHouse(bool ignoreEmpty = false)
    {
        var window = menuStack.Pop();
        if (menuStack.Count == 0)
        {
            if (!ignoreEmpty)
            {
                DeactivateCanvasWithDelay(window);
                secondButton.SetActive(true);
            }
            else
            {
                window.SetActive(false);
            }
        }
        else
        {
            DeactivateCanvasWithDelayForLaterPanel(window);
        }
    }

    public void closeMenu()
    {
        pushWindow(firstButton);
    }

    IEnumerator SetAnimatorParameterWithDelay(GameObject window)
    {
        var anim = window.GetComponent<Animator>();
        anim.SetBool("isActive", false);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        window.SetActive(false);
        closeMenu();
        inputController.setInputHandle<CharacterMovementInputHandle>();
    }

    IEnumerator SetAnimatorParameterWithDelayForLaterPanel(GameObject window)
    {
        var anim = window.GetComponent<Animator>();
        anim.SetBool("isActive", false);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        window.SetActive(false);
    }

    public void DeactivateCanvasWithDelay(GameObject window)
    {
        StartCoroutine(SetAnimatorParameterWithDelay(window));
    }

    public void DeactivateCanvasWithDelayForLaterPanel(GameObject window)
    {
        StartCoroutine(SetAnimatorParameterWithDelayForLaterPanel(window));
    }

}
