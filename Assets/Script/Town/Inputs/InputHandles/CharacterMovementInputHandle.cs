﻿using UnityEngine;
using Gamekit2D;

public class CharacterMovementInputHandle : InputHandle
{
    float startMousePositionX, currentMousePositionX;
    public GameObject target;
    private Direction inputDirection = Direction.none;
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
        this.target.GetComponent<CharacterController>().inputDirection = GetDirection();
    }

    public override Direction GetDirection()
    {
        return inputDirection;
    }
}
