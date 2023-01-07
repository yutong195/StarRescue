using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField]
    public AudioSource gameOverAudio;

    //why this does not become a serializefield
    private bool canPlayAudio;

    [SerializeField]
    public AudioSource paddleAudio;
    //[SerializeField]
    //public AudioSource wallAudio;

    public Sprite nor_sprite;
    public Sprite ac_sprite;
    public Sprite de_sprite;

    static public float speed;

    private Vector2 direction;
    private Vector2[] initDirections;
    private float SUPERPOWER_DURRATION = 8f;

    public int life;
    public GameObject[] hearts;
    public GameObject gameLost;

    RaycastHit2D hit;

    private float t;

    static public bool isFrozen = false;
    static public bool isFire = false;

    public static int monster_hit_total;

    //public TimeCount time;

    // Start is called before the first frame update
    void Start()
    {
        speed = GlobleData.getLevelSpeed(GlobleData.currentLevel);
        monster_hit_total = 0;
        canPlayAudio = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = nor_sprite;
        t = SUPERPOWER_DURRATION;

        

        initDirections = new Vector2[]{
            new Vector2(1, 1),
            new Vector2(1, -1),
            new Vector2(-1, 1),
            new Vector2(-1, -1)
        };
        // choose a random direction from the above and normalize it
        direction = initDirections[Random.Range(0, initDirections.Length)].normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //set superpower duration time
        if (isFire || isFrozen)
        {
            t -= Time.deltaTime * 8;
        }

        //superpower - ball sprite change
        if (t <= 0)
        {
            isFire = false;
            isFrozen = false;
            speed = GlobleData.getLevelSpeed(GlobleData.currentLevel);
            gameObject.GetComponent<SpriteRenderer>().sprite = nor_sprite;
            gameObject.GetComponent<Animator>().SetBool("isFire", isFire);
            gameObject.GetComponent<Animator>().SetBool("isFrozen", isFrozen);
        }

        



        //ball face the direction of its movement
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, 180+angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 720 * Time.deltaTime);

        //ball move
        //transform.Translate(direction * speed * Time.deltaTime);
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, Vector2.zero) > GlobleData.getLevelRadius(GlobleData.currentLevel) + 0.5
            && canPlayAudio)
        {
            this.GetComponent<SpriteRenderer>().color= new Color(1, 1, 1, 0.3f);
            gameOverAudio.Play();
            canPlayAudio = false;
        }

        // if the ball goes out of the bound
        if (transform.position.x > GlobleData.topRight.x + 1 ||
            transform.position.x < GlobleData.bottomLeft.x - 1 ||
            transform.position.y > GlobleData.topRight.y + 1 ||
            transform.position.y < GlobleData.bottomLeft.y - 1)
        {
            //life = life - 1;
            life = life - 1;
            MissingBall();
            Restart();
        }


        LayerMask mask = LayerMask.GetMask("PaddleBounce", "Wall");
        hit = Physics2D.Raycast(this.transform.position, direction, Mathf.Infinity, mask);

        //life < 1
        if (life<1)
        {
            Destroy(hearts[0].gameObject);
            //Time.timeScale = 0;
            transform.position = new Vector2(0, 0);
            gameLost.SetActive(true);
        }
        //life<2
        else if (life<2)
        {
            Destroy(hearts[1].gameObject); 
        }
        //life < 3
        else if(life<3)
        {
            Destroy(hearts[2].gameObject);
        }

        
    }

    //need to have a closer look at it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PaddleMerged")
        {
            //Debug.Log("Collide");
            paddleAudio.Play();
            // calculate the normal of the collision point
            //Vector2 paddle_position = collision.transform.position - GlobleData.getLevelCenter(GlobleData.currentLevel);
            direction = Vector2.Reflect(direction.normalized, hit.normal).normalized;
            this.GetComponent<Animator>().SetBool("isHit", true);
        }

        
        if (collision.tag == "wall")
        {
            //wallAudio.Play();
            //Vector2 normal_ = hit.point - (Vector2)GlobleData.getLevelCenter(0); 
            direction = Vector2.Reflect(direction.normalized, hit.normal).normalized;//get reflect direction

            this.GetComponent<Animator>().SetBool("isHit", true);
        }

        if (collision.name.StartsWith("MovingMonster"))
        {
            monster_hit_total++;
        }

        
    }

    public Vector2 getDirection()
    {
        return direction;
    }

    private void MissingBall() {
        GlobleData.MissingBall_total++;

        if (transform.position.x > 0)
        {
            GlobleData.MissingBall_Right++;
            //Debug.Log("missingRight:"+ GlobleData.MissingBall_Right);
        }
        else if (transform.position.x < 0)
        {
            GlobleData.MissingBall_Left++;
            //Debug.Log("missingLeft:" + GlobleData.MissingBall_Left);
        }
    }

    private void Restart()
    {
        if (CountHit.counthit > 0) {

            CountHit.counthit_total--; 
        }
        CountHit.counthit = -1;

        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        transform.position = Vector2.zero;
        direction = initDirections[Random.Range(0, initDirections.Length)].normalized;
        canPlayAudio = true;
    }

    public void Fire()
    {
        speed = 2.4f;
        t = SUPERPOWER_DURRATION;
        
        isFire = true;
        isFrozen = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = ac_sprite;
        gameObject.GetComponent<Animator>().SetBool("isFire", true);

    }
    public void Frozen()
    {
        speed = 2.4f;
        t = SUPERPOWER_DURRATION;
        
        isFrozen = true;
        isFire = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = de_sprite;
        gameObject.GetComponent<Animator>().SetBool("isFrozen", true);

    }

    //private void PuaseGame()
    //{
    //    Time.timeScale = 0;
    //}

}
