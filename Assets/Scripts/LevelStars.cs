using UnityEngine;

public class LevelStars : MonoBehaviour
{
    [SerializeField]
    public GameObject star1_full1;
    [SerializeField]
    public GameObject star1_full2;
    [SerializeField]
    public GameObject star1_full3;
    [SerializeField]
    public GameObject star1_empty1;
    [SerializeField]
    public GameObject star1_empty2;
    [SerializeField]
    public GameObject star1_empty3;


    [SerializeField]
    public GameObject star2_full1;
    [SerializeField]
    public GameObject star2_full2;
    [SerializeField]
    public GameObject star2_full3;
    [SerializeField]
    public GameObject star2_empty1;
    [SerializeField]
    public GameObject star2_empty2;
    [SerializeField]
    public GameObject star2_empty3;

    [SerializeField]
    public GameObject star3_full1;
    [SerializeField]
    public GameObject star3_full2;
    [SerializeField]
    public GameObject star3_full3;
    [SerializeField]
    public GameObject star3_empty1;
    [SerializeField]
    public GameObject star3_empty2;
    [SerializeField]
    public GameObject star3_empty3;

    private GameObject[,] star_full;
    private GameObject[,] star_empty;

    // Start is called before the first frame update
    void Start()
    {
        star_full = new GameObject[3, 3];
        star_empty = new GameObject[3, 3];

        star_full[0, 0] = star1_full1;
        star_full[0, 1] = star1_full2;
        star_full[0, 2] = star1_full3;
        star_full[1, 0] = star2_full1;
        star_full[1, 1] = star2_full2;
        star_full[1, 2] = star2_full3;
        star_full[2, 0] = star3_full1;
        star_full[2, 1] = star3_full2;
        star_full[2, 2] = star3_full3;

        star_empty[0, 0] = star1_empty1;
        star_empty[0, 1] = star1_empty2;
        star_empty[0, 2] = star1_empty3;
        star_empty[1, 0] = star2_empty1;
        star_empty[1, 1] = star2_empty2;
        star_empty[1, 2] = star2_empty3;
        star_empty[2, 0] = star3_empty1;
        star_empty[2, 1] = star3_empty2;
        star_empty[2, 2] = star3_empty3;

        int[] levelStars = { GlobleData.level01_star, GlobleData.level02_star, GlobleData.level03_star };

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < levelStars[i]; j++)
            {
                // Debug.Log("(" + i + ", " + j + ")");
                star_full[i, j].SetActive(true);
                star_empty[i, j].SetActive(false);
            }
        }
    }
}
