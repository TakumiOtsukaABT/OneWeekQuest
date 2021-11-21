using System.Collections;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [ReadOnly] public float leftLim, rightLim;
    [SerializeField,ReadOnly]private Floor ActiveFloor;
    [SerializeField, ReadOnly] GameObject character_2;
    [SerializeField, ReadOnly] private CameraFollow camera_0;
    [SerializeField, ReadOnly] private GameObject blackout_1;
    private Outlet outlet;
    // Start is called before the first frame update
    void Start()
    {
        outlet = GetComponent<Outlet>();
        ActiveFloor = transform.GetChild(0).GetComponent<Floor>();
        camera_0 = outlet.gameObjects[0].GetComponent<CameraFollow>();
        camera_0.setHaji(ActiveFloor);
        blackout_1 = outlet.gameObjects[1];
        character_2 = outlet.gameObjects[2];
        character_2.transform.localPosition = ActiveFloor.transform.Find("FloorStartPosition").transform.position;
        updateparams();
    }

    void updateparams()
    {
        this.leftLim = ActiveFloor.LeftLim;
        this.rightLim = ActiveFloor.RightLim;
        character_2.GetComponent<CharacterController>().setLeftRightLim(leftLim, rightLim);
    }

    private IEnumerator waitUpStairAnimation(string positionName, string floorName)
    {
        blackout_1.GetComponent<BlackoutController>().ActivateBlackout();
        camera_0.enabled = false;
        yield return new WaitForSeconds(blackout_1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        camera_0.enabled = true;
        ActiveFloor = GameObject.Find(floorName).GetComponent<Floor>();
        character_2.transform.localPosition = ActiveFloor.transform.Find(positionName).transform.position;
        updateparams();
        camera_0.setHaji(ActiveFloor);
        yield return new WaitUntil(camera_0.resetCameraPosition);
        blackout_1.GetComponent<BlackoutController>().DeactivateBlackoutWithDelay(0);
    }
    //private IEnumerator waitDownStairAnimation(string positionName, string floorName)
    //{
    //    blackout.GetComponent<BlackoutController>().ActivateBlackout();
    //    yield return new WaitForSeconds(blackout.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    //    ActiveFloor = GameObject.Find(floorName).GetComponent<Floor>();
    //    character.transform.position = ActiveFloor.transform.Find(positionName).transform.position;
    //    updateparams();
    //    var camera = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
    //    camera.setHaji(ActiveFloor);
    //    yield return new WaitUntil(camera.resetCameraPosition);
    //}

    public void moveFloorUp(string positionName, string floorName)
    {
        StartCoroutine(waitUpStairAnimation(positionName, floorName));
    }

    //public void moveFloorDown(string positionName, string floorName)
    //{
    //    StartCoroutine(waitDownStairAnimation(positionName, floorName));
    //}
}
