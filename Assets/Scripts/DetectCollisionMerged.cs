using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionMerged : MonoBehaviour
{
    public GameObject paddle_left;
    public GameObject paddle_right;
    public GameObject paddle_merged;
    public GameObject ball;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            //Debug.Log("Merged Hit Ball");
            paddle_left.transform.parent.position = new Vector3(-4.05f, 0f, 0f);
            paddle_left.transform.parent.rotation = Quaternion.Euler(0f, 0f, 0f);
            paddle_right.transform.parent.position = new Vector3(4.05f, 0f, 0f);
            paddle_right.transform.parent.rotation = Quaternion.Euler(0f, 0f, 0f);
            if (!paddle_left.activeInHierarchy && !paddle_right.activeInHierarchy)
            {
                paddle_left.SetActive(true);
                paddle_right.SetActive(true);
                paddle_merged.SetActive(false);
                DetectCollision.merged = false;
                Debug.Log("Paddle Split");


                
            }
            
        }
    }
    
}
