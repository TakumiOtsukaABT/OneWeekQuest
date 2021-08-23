using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    Stack<GameObject> menuStack = new Stack<GameObject>() { };
    [SerializeField] GameObject firstButton;

    public void Start()
    {
        pushWindow(firstButton);
    }

    public void pushWindow(GameObject window)
    {
        window.SetActive(true);
        menuStack.Push(window);
    }

    public void popWindow()
    {
        var window = menuStack.Pop();
        window.SetActive(false);
    }

}
