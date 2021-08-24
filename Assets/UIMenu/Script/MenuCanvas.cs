using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    public Stack<GameObject> menuStack = new Stack<GameObject>() { };
    [SerializeField] InputController inputController;
    [SerializeField] GameObject firstButton;
    [SerializeField] GameObject basePanel;
    [SerializeField] GameObject menuWindow;

    public void Start()
    {
        pushWindow(firstButton);
    }

    public void Update()
    {
        Debug.Log(menuStack.Peek());
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
            window.SetActive(false);
        }
    }

    public void closeMenu()
    {
        pushWindow(firstButton);
    }

    IEnumerator SetAnimatorParameterWithDelay(GameObject window)
    {
        var anim = menuWindow.GetComponent<Animator>();
        anim.SetBool("isActive", false);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        window.SetActive(false);
        closeMenu();
        inputController.setInputHandle<CharacterMovementInputHandle>();
    }

    public void DeactivateCanvasWithDelay(GameObject window)
    {
        StartCoroutine(SetAnimatorParameterWithDelay(window));
    }

}
