using UnityEngine;

public class InputController : MonoBehaviour
{
    protected InputHandle inputHandle;
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
            Debug.Log(inputHandle.GetType());
        }
    }

    public void setInputHandle<Type>() where Type : InputHandle
    {
        inputHandle = gameObject.GetComponent<Type>();
    }
}
