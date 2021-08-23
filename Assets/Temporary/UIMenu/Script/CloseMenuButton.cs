using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenuButton : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;

    public void onClick()
    {
        menuCanvas.GetComponent<MenuCanvas>().popWindow();
    }
}
