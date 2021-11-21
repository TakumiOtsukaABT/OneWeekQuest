using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonTemplate : MonoBehaviour
{
    [SerializeField] GameObject secondPanel;
    [SerializeField] MenuCanvas menuCanvas;
    virtual public void onClick()
    {
        menuCanvas.pushWindow(secondPanel);
    }
}
