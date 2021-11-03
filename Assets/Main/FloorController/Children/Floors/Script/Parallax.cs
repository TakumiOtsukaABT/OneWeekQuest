using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    [SerializeField,ReadOnly] private GameObject grandParent;
    [SerializeField,ReadOnly] private GameObject cam_0;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        grandParent = gameObject.transform.parent.parent.parent.gameObject;
        cam_0 = grandParent.GetComponent<Outlet>().gameObjects[0];
        startpos = transform.localPosition.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (cam_0.transform.position.x * parallaxEffect);
        transform.localPosition = new Vector3(startpos + dist, transform.localPosition.y, transform.localPosition.z);
    }
}
