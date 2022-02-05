using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayRender : MonoBehaviour
{
    [SerializeField] private float holdSeconds;
    [SerializeField] private float animationTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startToEnd());
    }

    private IEnumerator startToEnd()
    {
        yield return new WaitForSeconds(holdSeconds);
        GetComponent<Animator>().Play("DayRenderFadeOut");
        yield return new WaitForSeconds(animationTime);
        Destroy(this.gameObject);
    }
}
