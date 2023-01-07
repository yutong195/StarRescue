using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    [SerializeField]
    public Ball ball;
    [SerializeField]
    public GameObject boardLeft;
    [SerializeField]
    public float LeftPaddleSpeed;

    Vector3 central_point;  // spin center
    private Vector2 ballDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        central_point = GlobleData.getLevelCenter(0);
    }

    // Update is called once per frame
    void Update()
    {
        ballDirection = ball.getDirection().normalized;
        Vector2 targetPosition = new Vector2(ballDirection.x, ballDirection.y);

        //if (targetPosition.x <= 0)
        //{
        float angle = Vector2.SignedAngle(boardLeft.transform.position, targetPosition);
        boardLeft.transform.parent.RotateAround(central_point, Vector3.forward, angle * Time.deltaTime*LeftPaddleSpeed);
        //}
    }
}
