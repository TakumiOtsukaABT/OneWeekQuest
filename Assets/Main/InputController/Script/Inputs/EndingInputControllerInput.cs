using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingInputControllerInput : InputController
{
    // Start is called before the first frame update
    void Start()
    {
        inputHandle = gameObject.GetComponent<TownConversationInputHandle>();
    }
}
