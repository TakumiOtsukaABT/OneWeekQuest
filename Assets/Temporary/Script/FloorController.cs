using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public float leftLim, rightLim;
    private Floor ActiveFloor;
    // Start is called before the first frame update
    void Start()
    {
        ActiveFloor = transform.GetChild(0).GetComponent<Floor>();
        updateparams();
    }

    void updateparams()
    {
        this.leftLim = ActiveFloor.LeftLim;
        this.rightLim = ActiveFloor.RightLim;
    }
}
