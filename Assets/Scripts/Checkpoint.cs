using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject button_level02;
    public GameObject button_level02_disabled;

    public GameObject button_level03;
    public GameObject button_level03_disabled;

    // Start is called before the first frame update
    void Start()
    {
        if (GlobleData.unlockedLevel == 2)
        {
            button_level02.SetActive(true);
            button_level02_disabled.SetActive(false);

            button_level03.SetActive(false);
            button_level03_disabled.SetActive(true);
        }
        else if (GlobleData.unlockedLevel == 3)
        {
            button_level02.SetActive(true);
            button_level02_disabled.SetActive(false);

            button_level03.SetActive(true);
            button_level03_disabled.SetActive(false);
        }
    }
}
