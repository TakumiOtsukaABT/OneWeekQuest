using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGrowth_hukidashi : OpenMenuButton
{
    private void Start()
    {
        this.parent = gameObject.transform.parent.transform.parent.GetComponent<MenuCanvas>();
    }

    public new void onClick()
    {
        base.onClick();
        base.inputController.setInputHandle<CharacterMovementInputHandle>();
        GameObject.Find("OpenMenuButton").SetActive(false);
        GameObject[] hukidashis = GameObject.FindGameObjectsWithTag("hukidashi");
        foreach (var i in hukidashis)
        {
            i.SetActive(false);
        }
    }
}
