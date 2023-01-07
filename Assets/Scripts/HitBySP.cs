using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBySP : MonoBehaviour
{
    private float FROZEN_DURATION = 200;
    private float FIRE_DURATION = 6;
    private bool isHitbyFire = false;
    private bool isHitbyFrozen = false;
    private float frozen_t;
    private float fire_t;
    // Start is called before the first frame update
    void Start()
    {
        frozen_t = FROZEN_DURATION;
        fire_t = FIRE_DURATION;
    }

    // Update is called once per frame
    void Update()
    {
        //set superpower duration time
        if (isHitbyFire || isHitbyFrozen)
        {
            if (isHitbyFrozen)
            {
                frozen_t -= Time.deltaTime * 5;
            }
            else if (isHitbyFire)
            {
                fire_t -= Time.deltaTime * 5;
            }
        }

        //frozen ends
        if (frozen_t <= 0)
        {
            isHitbyFrozen = false;
            //sent the para. to movingmonster animator
                this.GetComponent<Animator>().SetBool("isFrozen", isHitbyFrozen);
                this.GetComponent<MonsterMove>().enabled = true;//start moving
            

        }

        //fire ends
        if (fire_t <= 0)
        {
            isHitbyFire = false;
            //sent the para. to movingmonster animator
                this.GetComponent<Animator>().SetBool("isFire", isHitbyFire);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            if (Ball.isFire) {
                
                isHitbyFrozen = false;
                isHitbyFire = true;
                fire_t = FIRE_DURATION;
                this.gameObject.GetComponent<Animator>().SetBool("isFire", isHitbyFire);// sent para to animator
            }
            if (Ball.isFrozen) {
               // Debug.Log("frozen");
                isHitbyFire = false;
                isHitbyFrozen = true;
                frozen_t = FROZEN_DURATION;
                this.gameObject.GetComponent<Animator>().SetBool("isFrozen", isHitbyFrozen);// sent para to animator
                this.GetComponent<MonsterMove>().enabled = false;
            }
        }
    }

}
