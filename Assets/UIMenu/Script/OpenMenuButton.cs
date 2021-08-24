using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuButton : MonoBehaviour
{
    MenuCanvas parent;
    [SerializeField] InputController inputController;
    [SerializeField] GameObject basePanel;
    [SerializeField] GameObject MenuWindow;

    void Start()
    {
        parent = gameObject.transform.parent.GetComponent<MenuCanvas>();
    }

    public void onClick()
    {
        parent.popWindow(true);
        parent.pushWindow(basePanel);
        inputController.setInputHandle<MenuInputHandle>();
    }
}
