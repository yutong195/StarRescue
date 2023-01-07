using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Slider>().value = GlobleData.BackgroundMusic_Volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
