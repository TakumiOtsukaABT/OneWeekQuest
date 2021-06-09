using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    [SerializeField] private float migihaji, hidarihaji;
    bool shouldFollow = true;

    private void LateUpdate()
    {
        shouldFollow = (target.transform.position.x > migihaji || target.transform.position.x < hidarihaji) ? false : true;
        if (shouldFollow)
        {
            followCamera();
        }
    }

    public bool resetCameraPosition()
    {
        followCamera();
        Vector3 desiredPosition = target.position + offset;
        return transform.position == desiredPosition;
    }

    public void setHaji(Floor floor)
    {
        migihaji = floor.RightLim - 4;
        hidarihaji = floor.LeftLim + 13.5f;
    }

    private void followCamera()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
