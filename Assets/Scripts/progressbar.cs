using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class progressbar : MonoBehaviour
{
    
    public GameObject MissionComplete;
    private int maximum;
    private int current;
    public Image mask;


    private GameObject PauseButton_right;
    private GameObject PauseButton_left;
    // Start is called before the first frame update
    void Start()
    {
        //maximum = GameObject.FindGameObjectsWithTag("monster01").Length;
        maximum = GameObject.Find("Monsters").transform.childCount;


        //GameObject[] Monster = GameObject.FindGameObjectsWithTag("monster01");
        //int numberOfMonster = Monster.Length;
        //maximum = numberOfMonster;


        PauseButton_right = GameObject.Find("PauseButton_right");
        PauseButton_left = GameObject.Find("PauseButton_left");
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        //GameObject[] liveMonster = GameObject.FindGameObjectsWithTag("monster01");
        //int numberOfliveMonster = liveMonster.Length;
        int numberOfliveMonster = GameObject.Find("Monsters").transform.childCount;
        current = maximum-numberOfliveMonster;

        if (numberOfliveMonster == 0)
        {
            Time.timeScale = 0f;
            MissionComplete.SetActive(true);
        }



        //pausebuttons disabled when player complete the game
        if (MissionComplete.activeInHierarchy)
        {
            if (PauseButton_right != null)
            {
                PauseButton_right.GetComponent<Button>().interactable = false;
            }

            if (PauseButton_left != null)
            {
                PauseButton_left.GetComponent<Button>().interactable = false;
            }
        }
        else {

            if (PauseButton_right != null)
            {
                PauseButton_right.GetComponent<Button>().interactable = true;
            }

            if (PauseButton_left != null)
            {
                PauseButton_left.GetComponent<Button>().interactable = true;
            }

        }

    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }

}
