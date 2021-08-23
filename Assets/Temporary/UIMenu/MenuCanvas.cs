using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    Stack<GameObject> menuStack = new Stack<GameObject>() { };

    public void stackWindow(GameObject window)
    {
        window.SetActive(true);
        menuStack.Push(window);
    }

}
