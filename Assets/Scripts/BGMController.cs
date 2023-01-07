using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().volume = GlobleData.BackgroundMusic_Volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BG_volume() {
        this.GetComponent<AudioSource>().volume = GlobleData.BackgroundMusic_Volume;
    }
}

