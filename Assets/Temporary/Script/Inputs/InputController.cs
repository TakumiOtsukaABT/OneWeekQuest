using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public InputHandle inputHandle;
    public bool active = true;
    InputTypes inputType = 0;

    // Start is called before the first frame update
    void Start()
    {
        inputHandle = gameObject.GetComponent<CharacterMovementInputHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
        inputHandle.handle();
        }
    }

    public void setInputHandle()
    {
        inputHandle = gameObject.GetComponent
    }
}
