using UnityEngine;
using UnityEngine.UI;

public class HitNumb : MonoBehaviour
{
    static public int CountHit_max;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "" + CountHit_max;
        
        
    }


}

