using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameObject paddle_left;
    public GameObject paddle_right;
    public GameObject paddle_merged;
    public GameObject ball;
    public float offset;
    static public bool merged;
    
    // Start is called before the first frame update
    void Start()
    {
        paddle_merged.SetActive(false);
        merged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!paddle_merged.activeInHierarchy)
        {
            
            //paddle_merged.transform.rotation = paddle_left.transform.rotation;
        }
     
        //if (Ball.ballHitPaddleMerged)
        //{
        //    paddle_merged.SetActive(false);
        //    paddle_left.SetActive(true);
        //    paddle_right.SetActive(true);
        //    Ball.ballHitPaddleMerged = false;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Paddle")
        {

            //Debug.Log("Collide");
            //collision happended in first quartile
            if (collision.transform.position.x >= 0 && collision.transform.position.y >= 0)
            {
                paddle_merged.transform.parent.position = new Vector3(collision.transform.position.x - offset
                    , collision.transform.position.y - offset, 0f) ;
            }
            //collision happened in second quartile
            else if(collision.transform.position.x <= 0 && collision.transform.position.y >= 0)
            {
                paddle_merged.transform.parent.position = new Vector3(collision.transform.position.x + offset
                    , collision.transform.position.y - offset, 0f);
            }
            //collision happended in third quartile
            else if (collision.transform.position.x < 0 && collision.transform.position.y < 0)
            {
                paddle_merged.transform.parent.position = new Vector3(collision.transform.position.x + offset
                    , collision.transform.position.y + offset, 0f);
            }
            //collision happended in fourth quartile
            else 
            {
                paddle_merged.transform.parent.position = new Vector3(collision.transform.position.x - offset
                    , collision.transform.position.y + offset, 0f);
            }

            //update the collision rotation to paddle_merged
            paddle_merged.transform.parent.rotation = collision.transform.rotation;
            //Debug.Log("Position:"+ collision.transform.position);
            //Debug.Log("Rotation:" + collision.transform.rotation);
            if(!paddle_merged.activeInHierarchy)
            {

                paddle_merged.SetActive(true);
                paddle_left.SetActive(false);
                paddle_right.SetActive(false);
                merged = true;
                Debug.Log("Paddle Merged");
                
            }
           

        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Paddle")
    //    {
    //        Debug.Log("collide");
    //        if (!paddle_merged.activeInHierarchy)
    //        {
    //            paddle_merged.SetActive(true);
    //            paddle_left.SetActive(false);
    //            paddle_right.SetActive(false);
                
    //        }

    //    }
        
    //}
}
