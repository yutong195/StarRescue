using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamondeffect : MonoBehaviour
{

    public GameObject Diamondmeter;
    public GameObject canvas;

    private bool lastisArrive = true;
    private bool end = false;
    private int n = 0;
    private float t = 10f;
    private GameObject TheDiamond;
    private int hit;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        end = false;
        hit = HitNumb.CountHit_max;
        
    }

    // Update is called once per frame
    void Update()
    {
        //CountHit.counthit_max = 12;
        
        //Debug.Log("hit" + hit);
        if (!end&& hit>0)
        {
            
            if (n < hit && lastisArrive) { TheDiamond = DiamondGeneration(); }

            float distance = Vector2.Distance(TheDiamond.transform.position, Diamondmeter.transform.position);
            if (distance >= 1)
            {
                TheDiamond.transform.position = Vector3.Lerp(TheDiamond.transform.position, Diamondmeter.transform.position, t * Time.deltaTime);
                lastisArrive = false;
            }
            else
            {
                Destroy(TheDiamond);
                n++;
                lastisArrive = true;
                if (n == hit) { end = true; }
            }
        }



    }
    private GameObject DiamondGeneration()
    {
        GameObject newdiamond = Instantiate(Diamondmeter, this.transform.position, Quaternion.identity);
        newdiamond.transform.SetParent(canvas.transform);
        return newdiamond;
    }
}
