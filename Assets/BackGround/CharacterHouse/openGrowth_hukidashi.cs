using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGrowth_hukidashi : OpenMenuButton
{
    private void Start()
    {
        this.parent = gameObject.transform.parent.transform.parent.GetComponent<MenuCanvas>();
    }
}
