using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuButton : MonoBehaviour
{
    protected MenuCanvas parent;
    [SerializeField] protected InputController inputController;
    [SerializeField] GameObject basePanel;

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
