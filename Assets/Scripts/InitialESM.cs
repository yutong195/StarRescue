using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialESM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Slider>().value = GlobleData.GameEffectSound_Volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
