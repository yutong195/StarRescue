using System.Collections.Generic;
using UnityEngine;

//why paddle is in camera

public class PaddleTrain : MonoBehaviour
{
    [SerializeField]
    public GameObject boardRight;
    
    [SerializeField]
    public GameObject paddleMerged;

    //static public GameObject paddle_left_clone;
    //static public GameObject paddle_right_clone;


    Vector3 central_point;  // spin center


    private Collider2D collider2D_right;
   
    private Collider2D collider2D_merged;


    Camera cam;
    public class DragObject
    {
        public Collider2D paddle;
        public int fingerID;
    }
    public Dictionary<int, DragObject> draggedObjects = new Dictionary<int, DragObject>();
    // Start is called before the first frame update
    void Start()
    {
        //paddle_left_clone = Instantiate(boardLeft, boardLeft.transform.position, boardLeft.transform.rotation);
        //paddle_right_clone = Instantiate(boardRight, boardRight.transform.position, boardRight.transform.rotation);
        Input.multiTouchEnabled = true;
        collider2D_right = boardRight.GetComponent<Collider2D>();
        
        collider2D_merged = paddleMerged.GetComponent<Collider2D>();

        central_point = GlobleData.getLevelCenter(0);
        //paddleMerged.SetActive(false);
        cam = Camera.main;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                Vector2 touchPosition = cam.ScreenToWorldPoint(touch.position);
                //Debug.Log(touchPosition);

                if (touch.phase == TouchPhase.Began)
                {
                    LayerMask mask = LayerMask.GetMask("Controller");
                    Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition, mask);
                    if (touchedCollider == collider2D_right || touchedCollider == collider2D_merged)
                    {
                        DragObject drag0;

                        if (!draggedObjects.TryGetValue(touch.fingerId, out drag0))
                        {
                            drag0 = new DragObject();


                            draggedObjects.Add(touch.fingerId, drag0);
                        }
                        drag0.fingerID = touch.fingerId;
                        drag0.paddle = touchedCollider;
                    }
                }

                else if (touch.phase == TouchPhase.Moved)
                {
                    DragObject drag0;

                    if (draggedObjects.TryGetValue(touch.fingerId, out drag0))
                    {
                        //why have this situation?
                        if (drag0.paddle == null)
                        {
                            draggedObjects.Remove(touch.fingerId);
                            //continue;
                        }
                        Vector2 targetPosition = new Vector2(touchPosition.x, touchPosition.y);
                        float angle = Vector2.SignedAngle(drag0.paddle.transform.position, targetPosition);

                        //setting the boundary
                        //if (drag0.paddle == collider2D_right && touchPosition.x <= 0)
                        //{

                        //drag0.paddle.transform.position = new Vector2(drag0.paddle.transform.position.x, drag0.paddle.transform.position.y);
                        //}
                        //else if (drag0.paddle == collider2D_left && touchPosition.x >= 0) {

                        //drag0.paddle.transform.position = new Vector2(drag0.paddle.transform.position.x, drag0.paddle.transform.position.y);
                        //}



                        //else
                        //achieve the real movement of rotating around the central point
                        if (drag0.paddle == collider2D_right || drag0.paddle == collider2D_merged)
                        {
                            drag0.paddle.transform.RotateAround(central_point, Vector3.forward, angle);
                        }

                        //Debug.Log(drag0.paddle.transform.position);



                    }

                }

                else if (touch.phase == TouchPhase.Ended)
                {
                    DragObject drag0;
                    if (draggedObjects.TryGetValue(touch.fingerId, out drag0))
                    {

                        draggedObjects.Remove(touch.fingerId);
                    }
                }

            }

        }
    }
}
