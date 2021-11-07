using System.Collections;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [ReadOnly] public float leftLim, rightLim;
    [SerializeField,ReadOnly]private Floor ActiveFloor;
    GameObject character;
    private CameraFollow camera;
    private GameObject blackout;
    // Start is called before the first frame update
    void Start()
    {
        ActiveFloor = transform.GetChild(0).GetComponent<Floor>();
        camera = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        camera.setHaji(ActiveFloor);
        blackout = GameObject.Find("Blackout");
        character = GameObject.Find("Character");
        character.transform.localPosition = ActiveFloor.transform.Find("FloorStartPosition").transform.position;
        updateparams();
    }

    void updateparams()
    {
        this.leftLim = ActiveFloor.LeftLim;
        this.rightLim = ActiveFloor.RightLim;
        character.GetComponent<CharacterController>().setLeftRightLim(leftLim, rightLim);
    }

    private IEnumerator waitUpStairAnimation(string positionName, string floorName)
    {
        blackout.GetComponent<BlackoutController>().ActivateBlackout();
        camera.enabled = false;
        yield return new WaitForSeconds(blackout.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        camera.enabled = true;
        ActiveFloor = GameObject.Find(floorName).GetComponent<Floor>();
        character.transform.localPosition = ActiveFloor.transform.Find(positionName).transform.position;
        updateparams();
        camera.setHaji(ActiveFloor);
        yield return new WaitUntil(camera.resetCameraPosition);
        blackout.GetComponent<BlackoutController>().DeactivateBlackoutWithDelay(0);
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
