using UnityEngine;

public class MonsterAppear : MonoBehaviour
{
    public static int normal_monster_amount;
    public GameObject movingMonster1;
    public GameObject movingMonster2;

    // Start is called before the first frame update
    void Start()
    {
        normal_monster_amount = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if(normal_monster_amount == 3)
        {
            if (movingMonster1) {
                movingMonster1.SetActive(true);
            }
        }
        if (normal_monster_amount == 1)
        {
            if (movingMonster2) {
                movingMonster2.SetActive(true);
            }
        }
    }
}
