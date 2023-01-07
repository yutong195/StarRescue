using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCount : MonoBehaviour
{
    public Text timeCountdownText;
    public float timeLeft;
    public bool timeOn = false;
    public GameObject gameLost;
    public Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        timeOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeOn)
        {
            if(ball.life>=1)
            {
                if(timeLeft>0)
                    {
                        timeLeft -= Time.deltaTime;
                        updateTimer(timeLeft);
                
                    }
                else
                    {
                        //Debug.Log("Time is UP!");
                        //timeLeft = 0;
                        //timeOn = false;
                        //restart the game
                
                        gameLost.SetActive(true);
                        ball.transform.position = new Vector2(0,0);
                        //Time.timeScale = 0;
                        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
            }
            
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timeCountdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
