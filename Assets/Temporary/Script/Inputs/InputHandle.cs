using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandle : MonoBehaviour
{
    virtual public void handle()
    {
        return;
    } 
    virtual public Direction GetDirection()
    {
        return Direction.none;
    }
}
