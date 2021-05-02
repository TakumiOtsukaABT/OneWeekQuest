using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float startMousePositionX, currentMousePositionX;
    Direction inputDirection = Direction.none;
    public float movingSpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputHandling();
        switch (inputDirection)
        {
            case Direction.none:
                break;
            case Direction.left:
                this.transform.Translate(-movingSpeed*Time.deltaTime, 0, 0);
                break;
            case Direction.right:
                this.transform.Translate(movingSpeed*Time.deltaTime, 0, 0);
                break;
        }
    }

    private void inputHandling()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.startMousePositionX = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0))
        {
            this.currentMousePositionX = Input.mousePosition.x;
            if (startMousePositionX < currentMousePositionX)
            {
                this.inputDirection = Direction.right;
            }
            else
            {
                this.inputDirection = Direction.left;
            }
        }
        else
        {
            this.inputDirection = Direction.none;
        }
    }
}
