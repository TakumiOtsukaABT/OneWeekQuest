using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuButton : MonoBehaviour
{
    MenuCanvas parent;
    [SerializeField] InputController inputController;
    [SerializeField] GameObject openTarget;

    void Start()
    {
        parent = gameObject.transform.parent.GetComponent<MenuCanvas>();
    }

    public void onClick()
    {
        parent.popWindow(true);
        parent.pushWindow(openTarget);
        inputController.setInputHandle<MenuInputHandle>();
    }
}
