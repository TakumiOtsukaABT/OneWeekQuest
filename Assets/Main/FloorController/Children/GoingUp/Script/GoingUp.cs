using UnityEngine;


public class GoingUp : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    public string nextPositionName = "";
    public string nextFloorName = "";

    public void Onclick()
    {
        transform.root.gameObject.GetComponent<FloorController>().moveFloorUp(nextPositionName, nextFloorName);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.SetActive(false);
    }
}
