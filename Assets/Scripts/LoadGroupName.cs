using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGroupName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().text = "欢迎, " +  GlobleData.PlayerID + "!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
