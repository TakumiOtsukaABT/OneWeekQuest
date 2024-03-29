﻿using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField,ReadOnly]protected InputHandle inputHandle;
    [ReadOnly] public bool active = true;

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

    public void setInputHandle<Type>() where Type : InputHandle
    {
        inputHandle = gameObject.GetComponent<Type>();
    }
}
