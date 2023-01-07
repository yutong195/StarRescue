using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBouncePos : MonoBehaviour
{
    //the Ball script
    public Ball ball;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    //public GameObject paddleAll;
    //the ball instance
    public GameObject ballInstance;

    //private Vector2 speedDirection;
    private Vector3 startPos;
    private Vector3 endPos;

    public float offset;
    //private Vector3 next_pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the direction of the ball
        //speedDirection = ball.getDirection();

        //achieve the bounce paddle movements
        Vector3 horizontal = new Vector3(1, 0, 0);
        startPos = leftPaddle.transform.position;
        endPos = rightPaddle.transform.position;

        //calculte the center point of the center paddle
        Vector3 centerPos = new Vector3(startPos.x + endPos.x, startPos.y + endPos.y) / 2f;

        //calculate the relative distance between left paddle and right paddle
        float distance = Vector3.Distance(new Vector3(startPos.x, startPos.y, 0), new Vector3(endPos.x, endPos.y, 0));

        //calculate the angle between the left and right paddle
        
        Vector3 relative = endPos - startPos;
        float angle = Vector3.SignedAngle(horizontal, relative, Vector3.forward);
        //float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        //Debug.Log(startPos);
        //Debug.Log(endPos);

        //achieve the bounce paddle movement
        transform.position = centerPos;
        transform.rotation = Quaternion.Euler(0f, 0f, angle+90);
        transform.localScale = new Vector3( 0.02f, distance-offset, 1);

        //shoot raycast from ball to detect whether will hit bounce paddle
        //LayerMask mask = LayerMask.GetMask("PaddleBounce");
        //RaycastHit2D hit = Physics2D.Raycast(ball.transform.position, speedDirection, Mathf.Infinity, mask);
        //if (hit && hit.collider)
        //{

        //    if (hit.collider.tag == "PaddleMerged")//hit merged paddle
        //    {

        //        Vector3 ref_Direction = Vector2.Reflect(speedDirection, hit.normal);//get reflect direction
        //        Debug.Log(ref_Direction);
        //        //get the next position of where the paddle is going to be
        //        next_pos = GetPos(ref_Direction, hit.transform.position);


        //    }

        //}
         
    }

    //private Vector3 GetPos(Vector3 dir, Vector3 pos)
    //{
    //    Vector3 update_pos;
    //    LayerMask mask = LayerMask.GetMask("Wall");
    //    RaycastHit2D hit = Physics2D.Raycast(pos, dir, Mathf.Infinity, mask);
    //    update_pos = hit.transform.position;

    //    return update_pos;
                
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Ball")
    //    {
    //        transform.localScale = new Vector3(0.2f, 1, 1);
    //        transform.parent.position = next_pos;
    //        //Debug.Log(next_pos);
    //    }
    //}




}
