using UnityEngine;


public class GoingUp : MonoBehaviour
{

    [SerializeField] string floorName = "";
    public string nextPositionName = "";
    public string nextFloorName = "";
    public string stairPositionClassName = "";


    public void Onclick()
    {
        Debug.Log("tttt" + stairPositionClassName);
        Debug.Log("tttt" + floorName);
        Debug.Log("tttt" + nextFloorName);
        GameObject.Find("Character").transform.position = transform.parent.Find("StairPosition").transform.position;
        transform.root.gameObject.GetComponent<FloorController>().moveFloor(nextPositionName, nextFloorName);
        Debug.Log("tttt" + nextPositionName);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.transform.Find("Canvas").gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.transform.Find("Canvas").gameObject.SetActive(false);
    }
}
