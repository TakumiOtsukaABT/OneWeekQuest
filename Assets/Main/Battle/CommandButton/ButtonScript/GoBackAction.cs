using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackAction : BaseActionCommand
{
    [SerializeField] private GameObject waza_panel;

    public override void runActionCommand()
    {
        waza_panel.SetActive(false);
    }
}
