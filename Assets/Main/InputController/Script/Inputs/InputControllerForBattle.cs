using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllerForBattle : InputController
{
    
    private void Start()
    {
        base.inputHandle = gameObject.GetComponent<Battle_ReadInputHandle>();
    }

 
}
