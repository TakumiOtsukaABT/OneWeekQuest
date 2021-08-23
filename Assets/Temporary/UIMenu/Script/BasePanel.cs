using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    [SerializeField] GameObject menuWindow;
    // Start is called before the first frame update
    void OnEnable()
    {
        menuWindow.GetComponent<Animator>().SetBool("isActive", true);
    }
}
