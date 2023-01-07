using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarName : MonoBehaviour
{
    public string L01_name;
    public string L02_name;
    public string L03_name;
    // Start is called before the first frame update
    void Start()
    {
        if (GlobleData.currentLevel == 1)
        {
            gameObject.GetComponent<Text>().text = L01_name;
        }
        else if (GlobleData.currentLevel == 2)
        {
            gameObject.GetComponent<Text>().text = L02_name;
        }
        else
        {
            gameObject.GetComponent<Text>().text = L03_name;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
