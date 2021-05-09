using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float startMousePositionX, currentMousePositionX;
    Direction inputDirection = Direction.none;
    public float movingSpeed = 0.0f;
    private bool inputBoolean = true;
    AnimationHandle animationHandle;

    FloorController floorController;

    public bool InputBoolean { get => inputBoolean; set => inputBoolean = value; }

    // Start is called before the first frame update
    void Start()
    {
        floorController = GameObject.Find("FloorController").GetComponent<FloorController>();
        animationHandle = GetComponent<AnimationHandle>();

    }

    // Update is called once per frame
    void Update()
    {
        inputHandling();
        switch (inputDirection)
        {
            case Direction.none:
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
                break;
            case Direction.left:
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
                if (transform.position.x > floorController.leftLim)
                {
                this.transform.Translate(-movingSpeed*Time.deltaTime, 0, 0);
                    animationHandle.Running = true;
                }
                break;
            case Direction.right:
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
                if (transform.position.x < floorController.rightLim)
                {
                this.transform.Translate(movingSpeed*Time.deltaTime, 0, 0);
                    animationHandle.Running = true;
                }
                break;
        }
    }

    private void inputHandling()
    {
        if (!inputBoolean)
        {
            Debug.Log("inputDisabled");
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            this.startMousePositionX = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0))
        {
            this.currentMousePositionX = Input.mousePosition.x;
            if (Mathf.Abs(this.startMousePositionX - this.currentMousePositionX) > 100)
            {
                if (startMousePositionX < currentMousePositionX)
                {
                    this.inputDirection = Direction.right;
                }
                else
                {
                    this.inputDirection = Direction.left;
                }
            }
        }
        else
        {
            this.inputDirection = Direction.none;
            this.animationHandle.Running = false;
        }
    }
}
