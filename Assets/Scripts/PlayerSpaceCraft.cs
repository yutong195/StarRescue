using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpaceCraft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().text = GlobleData.PlayerID + "的飞船";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
