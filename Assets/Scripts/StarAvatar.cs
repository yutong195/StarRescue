using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAvatar : MonoBehaviour
{
    public Sprite L01_sprite;
    public Sprite L02_sprite;
    public Sprite L03_sprite;
    // Start is called before the first frame update
    void Start()
    {
        if (GlobleData.currentLevel == 1) {
            gameObject.GetComponent<SpriteRenderer>().sprite = L01_sprite;
        }
        else if (GlobleData.currentLevel == 2) {
            gameObject.GetComponent<SpriteRenderer>().sprite = L02_sprite;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().sprite = L03_sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
