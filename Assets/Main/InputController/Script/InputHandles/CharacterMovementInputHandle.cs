using UnityEngine;
using Gamekit2D;

public class CharacterMovementInputHandle : InputHandle
{
    float startMousePositionX, currentMousePositionX;
    [SerializeField,ReadOnly] private GameObject character_0;
    private Direction inputDirection = Direction.none;

    private void Start()
    {
        character_0 = gameObject.GetComponent<Outlet>().gameObjects[0];
    }

    public override void handle()
    {
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
        }
        this.character_0.GetComponent<CharacterController>().inputDirection = GetDirection();
    }

    public override Direction GetDirection()
    {
        return inputDirection;
    }
}
