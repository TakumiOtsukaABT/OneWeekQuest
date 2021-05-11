using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public InputHandle[] inputHandles;
    InputTypes inputType = 0;
    // Start is called before the first frame update
    void Start()
    {
        inputHandles[0] = gameObject.GetComponent<CharacterMovementInputHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputHandles[(int)inputType].enabled)
        {
        inputHandles[(int)inputType].handle();
        }
    }
}
