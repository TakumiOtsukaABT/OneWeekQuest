using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float idouHidariSeigen = -15.0f;
    public float idouMigiSeigen = 10.0f;
    [SerializeField, ReadOnly] private float leftLim;
    [SerializeField, ReadOnly] private float rightLim;
    [ReadOnly] public Direction inputDirection = Direction.none;
    public float movingSpeed = 0.0f;
    private bool inputBoolean = true;
    AnimationHandle animationHandle;

    public bool InputBoolean { get => inputBoolean; set => inputBoolean = value; }

    // Start is called before the first frame update
    void Start()
    {
        animationHandle = GetComponent<AnimationHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (inputDirection)
        {
            case Direction.none:
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
                this.animationHandle.Running = false;
                break;
            case Direction.left:
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
                if (transform.position.x > this.leftLim + idouHidariSeigen)
                {
                    this.transform.Translate(-movingSpeed * Time.deltaTime, 0, 0);
                    animationHandle.Running = true;
                }
                break;
            case Direction.right:
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
                if (transform.position.x < this.rightLim + idouMigiSeigen)
                {
                    this.transform.Translate(movingSpeed * Time.deltaTime, 0, 0);
                    animationHandle.Running = true;
                }
                break;
        }
    }

    public void setLeftRightLim(float leftLim, float rightLim)
    {
        this.leftLim = leftLim;
        this.rightLim = rightLim;
    }
}
