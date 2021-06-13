using System.Collections;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public float leftLim, rightLim;
    private Floor ActiveFloor;
    GameObject character;
    private CameraFollow camera;
    // Start is called before the first frame update
    void Start()
    {
        ActiveFloor = transform.GetChild(0).GetComponent<Floor>();
        camera = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        camera.setHaji(ActiveFloor);
        character = GameObject.Find("Character");
        updateparams();
    }

    void updateparams()
    {
        this.leftLim = ActiveFloor.LeftLim;
        this.rightLim = ActiveFloor.RightLim;
    }

    private IEnumerator waitUpStairAnimation(string positionName, string floorName)
    {
        character.GetComponent<AnimationHandle>().animationUpStairs();

        yield return new WaitForSeconds(character.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length / 0.5f + 1.0f);
        ActiveFloor = GameObject.Find(floorName).GetComponent<Floor>();
        character.transform.position = ActiveFloor.transform.Find(positionName).transform.position;
        updateparams();
        camera.setHaji(ActiveFloor);
        yield return new WaitUntil(camera.resetCameraPosition);
    }
    private IEnumerator waitDownStairAnimation(string positionName, string floorName)
    {
        character.GetComponent<AnimationHandle>().animationDownStairs();
        yield return new WaitForSeconds(character.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length / 0.5f + 1.0f);
        ActiveFloor = GameObject.Find(floorName).GetComponent<Floor>();
        character.transform.position = ActiveFloor.transform.Find(positionName).transform.position;
        updateparams();
        var camera = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        camera.setHaji(ActiveFloor);
        yield return new WaitUntil(camera.resetCameraPosition);
    }

    public void moveFloorUp(string positionName, string floorName)
    {
        StartCoroutine(waitUpStairAnimation(positionName, floorName));
    }

    public void moveFloorDown(string positionName, string floorName)
    {
        StartCoroutine(waitDownStairAnimation(positionName, floorName));
    }
}
