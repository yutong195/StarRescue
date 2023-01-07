using UnityEngine;

public class RatingStars : MonoBehaviour
{
    public GameObject star_full1;
    public GameObject star_full2;
    public GameObject star_full3;
    public GameObject star_blank1;
    public GameObject star_blank2;
    public GameObject star_blank3;

    private GameObject[] star_full;
    private GameObject[] star_blank;
    private int rate;

    // Start is called before the first frame update
    void Start()
    {
        star_full = new GameObject[3];
        star_blank = new GameObject[3];

        star_full[0] = star_full1;
        star_full[1] = star_full2;
        star_full[2] = star_full3;

        star_blank[0] = star_blank1;
        star_blank[1] = star_blank2;
        star_blank[2] = star_blank3;

        rate = Ball.monster_hit_total * 4 / (CountHit.paddle_hit_total + 1);
        if (rate >= 4)
            rate = 3;

        if (GlobleData.currentLevel == 1 && rate > GlobleData.level01_star)
            GlobleData.level01_star = rate;
        else if (GlobleData.currentLevel == 2 && rate > GlobleData.level02_star)
            GlobleData.level02_star = rate;
        else if (GlobleData.currentLevel == 3 && rate > GlobleData.level03_star)
            GlobleData.level03_star = rate;

        for (int i = 0; i < rate; i++)
        {
            star_full[i].SetActive(true);
            star_blank[i].SetActive(false);
        }
    }
}
