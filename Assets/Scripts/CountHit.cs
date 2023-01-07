using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountHit : MonoBehaviour
{
    public TextMeshProUGUI right_tex;
    public Text right_t;
    public TextMeshProUGUI left_tex;
    public Text left_t;
     
    //public TextMeshPro tex;
    static public int counthit = -1;
    private const float DISAPPEAR_TIMER_MAX = 1f;
    private float disappearTimer;
    private bool hit = false;

    static public int counthit_max;
    static public int counthit_total=0;
    static public int Hit_Left;
    static public int Hit_Right;


    static public int paddle_hit_total;

    // Start is called before the first frame update
    void Start()
    {
        counthit_max = 0;
        counthit = -1;
        paddle_hit_total = 0;
        Hit_Left = 0;
        Hit_Right = 0;


        disappearTimer = DISAPPEAR_TIMER_MAX;

    }

    // Update is called once per frame
    void Update()
    {
        //if the player did not catch the ball
        if (this.transform.position.x > GlobleData.topRight.x ||
            this.transform.position.x < GlobleData.bottomLeft.x||
            this.transform.position.y > GlobleData.topRight.y ||
            this.transform.position.y < GlobleData.bottomLeft.y )
        {
            if (counthit > counthit_max)
            {
                counthit_max = counthit;
            }
            ShowHitNumber();
        }
        if (CountHit.counthit == -1) {
            ShowHitNumber();
        }

        if (hit)
        {
            
            if (disappearTimer >= DISAPPEAR_TIMER_MAX*.5f)
            {
                //first half of the popup lifetime
                float increaseScaleAmount = 1f;
                right_tex.transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
                left_tex.transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
            }
            else
            {
                
                //second half of the popup lifetime
                float decreaseScaleAmount = 1f;
                right_tex.transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
                left_tex.transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
                
            }

            if (disappearTimer >= 0) {
                disappearTimer-=Time.deltaTime;
            }
            else {
                hit=false;
                disappearTimer = DISAPPEAR_TIMER_MAX;
                right_tex.transform.localScale = new Vector3(1,1,1);
                left_tex.transform.localScale = new Vector3(1, 1, 1);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PaddleMerged")
        {
            counthit++;
            paddle_hit_total++;
            counthit_total++;
            if (counthit > counthit_max)
            {
                counthit_max = counthit;
            }


            hit = true;
            ShowHitNumber();

            //if (collision.gameObject.name == "PaddleRight") {
            //    Hit_Right++;
            //}
            //else if(collision.gameObject.name == "PaddleLeft"){
            //    Hit_Left++;
            //}


        }
        
    }

    private void ShowHitNumber() {
        //is there is a nice catch
        if (counthit > 0)
        {
            string content = "+" + counthit;
            //tex.fontSize = 100;
            //tex.fontStyle = FontStyles.Bold;
            right_t.text = "连击";
            right_tex.text = content;
            left_t.text = "连击";
            left_tex.text = content;
        }
        //if player didnot catch the ball, clear the text
        else
        {
            //Debug.Log("clear");
            right_t.text = "";
            left_t.text = "";
            right_tex.text = "";
            left_tex.text = "";

        }
    }

}
