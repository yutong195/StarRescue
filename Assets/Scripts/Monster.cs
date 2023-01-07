using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    public int LiveValueMax = 3;
    [SerializeField]
    public GameObject deathParticles;
    [SerializeField]
    public AudioSource firstHitAudio;
    [SerializeField]
    public AudioSource secondHitAudio;
    [SerializeField]
    public AudioSource thirdHitAudio;
    [SerializeField]
    public AudioSource rescuedSuccessfully;
    //public static bool playRescueAudio;
    [SerializeField]
    public Sprite magicBallCrack;
    [SerializeField]
    public Sprite maigcBallExplode;

    private Camera camera;
    //[SerializeField]
    //private GameObject rescuedSign;

    private float currentLiveValue;

    // Start is called before the first frame update
    void Start()
    {
        currentLiveValue = LiveValueMax;
        float radius = GlobleData.getLevelRadius(GlobleData.currentLevel);
        transform.position = GetRandomPosition(radius - 0.4f);
        this.transform.GetChild(0).gameObject.SetActive(false);
        camera = FindObjectOfType<Camera>();
        //playRescueAudio = false;
    }

    Vector2 GetRandomPosition(float maxRadius)
    {
        float angle = (float)Random.Range(0f, 4 * Mathf.PI);  // get a random angle
        float radius = (float)Random.Range(0.6f, maxRadius);
        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);
        Vector2 randomPoint = new Vector2(x, y);
        if (randomPoint.y < -2f)
        {
            randomPoint.y = randomPoint.y + 1f;
        }
        if (randomPoint.y < 0f & randomPoint.x > 2f)
        {
            randomPoint.x = randomPoint.x - 0.3f;
        }
        if (randomPoint.y < 0f & randomPoint.x < -2f)
        {
            randomPoint.x = randomPoint.x + 0.3f;
        }
        return randomPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            Ball.monster_hit_total++;

            //currentLiveValue -=(float)Ball.speed;
            currentLiveValue--;
            if (this.name.StartsWith("monster")) { this.GetComponent<Animator>().SetBool("isHit", true); }
            

            if (currentLiveValue <= 0)
            {
                if (!transform.name.StartsWith("MovingMonster"))
                {
                    MonsterAppear.normal_monster_amount--;
                }

                Instantiate(deathParticles, transform.position, Quaternion.identity);

                thirdHitAudio.Play();
                //playRescueAudio = true;
                

                Invoke("Show", 0.1f);
                AudioSource.PlayClipAtPoint(rescuedSuccessfully.clip, camera.transform.position, 1f);
                Invoke("Destroy", 1f);
                // Destroy();

            }
            else
            {
                //gameObject.GetComponent<SpriteRenderer>().color.a;

                //Color color = this.GetComponent<SpriteRenderer>().material.color;
                //color.a -= (float)1 / LiveValueMax;
                //this.GetComponent<SpriteRenderer>().material.color = color;

                if (currentLiveValue == 1)
                {
                    secondHitAudio.Play();
                    if(!transform.name.StartsWith("MovingMonster"))
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = maigcBallExplode;
                    }
                }

                else
                {
                    firstHitAudio.Play();
                    if (!transform.name.StartsWith("MovingMonster"))
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = magicBallCrack;
                    }
                    
                }
                    
            }
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Show()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        Invoke("Hide", 1.5f);
    }
    public void Hide()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
}
