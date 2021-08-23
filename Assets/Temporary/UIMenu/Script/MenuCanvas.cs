using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    public Stack<GameObject> menuStack = new Stack<GameObject>() { };
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
        window.SetActive(false);
        if (menuStack.Count == 0)
        {
            if (!ignoreEmpty)
            {
                closeMenu();
            }
        }
    }

    public void closeMenu()
    {
        pushWindow(firstButton);
    }

}
