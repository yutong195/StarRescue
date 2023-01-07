using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Concensus : MonoBehaviour
{
    public Slider leftConcensus;
    public Slider rightConcensus;
    public GameObject concensusBar;
    public GameObject spaceCraft;
    //public bool[] store_is_purchased = { false, false, false, false, false, false, false, false };
    //static public Dictionary<string, bool> store_is_purchased = new Dictionary<string, bool>();

    
    private int store_number;

    public GameObject purchaseSuccessful;

    public GameObject purchaseFailed;

    [SerializeField]
    public AudioSource reachConcensus;

    [SerializeField]
    public AudioSource failConcensus;
    //static public bool is_purchased = false;
    //public GameObject solarBoard;
    
    // Start is called before the first frame update
    void Start()
    {
        leftConcensus.minValue = 0;
        leftConcensus.maxValue = 1;
        rightConcensus.minValue = 0;
        rightConcensus.maxValue = 1;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int j = 0; j < this.transform.childCount; j++)
        {
            if (this.transform.GetChild(j).name == ButtonClick.object_name)
            {
                store_number = j;
            }
        }


        if (leftConcensus.value == 1 && rightConcensus.value == 1)
        {
            concensusBar.SetActive(false);
            //show the purchase successful UI
            //Show the reach concensus sign
            Invoke("Show",0f);

            //play the reach concensus audio
            reachConcensus.Play();

            leftConcensus.value = 0.5f;
            rightConcensus.value = 0.5f;
            //store_is_purchased[ButtonClick.object_name] = true;


            for(int i = 0; i < spaceCraft.transform.childCount; i++)
            {
                if(spaceCraft.transform.GetChild(i).name == ButtonClick.object_name)
                {
                    spaceCraft.transform.GetChild(i).gameObject.SetActive(true);
                }
            }

            this.transform.GetChild(store_number).gameObject.GetComponent<ButtonClick>().purchased = true;
            this.transform.GetChild(store_number).gameObject.GetComponent<ButtonClick>().armed = true;
            GlobleData.Diamond -= this.transform.GetChild(store_number).gameObject.GetComponent<ButtonClick>().Price;
            //is_purchased = store_is_purchased[i];


            //Debug.Log(ButtonClick.object_name + store_is_purchased[ButtonClick.object_name]);
        }

        else if (leftConcensus.value == 1 && rightConcensus.value == 0)
        {
            concensusBar.SetActive(false);
            //Show the purchased failed sign
            Invoke("ShowFailed", 0f);
            //play fail concensus audio
            failConcensus.Play();
            //set the value of the slider to origin
            leftConcensus.value = 0.5f;
            rightConcensus.value = 0.5f;
            //store_is_purchased[ButtonClick.object_name] = false;
            //is_purchased = store_is_purchased[i];

            this.transform.GetChild(store_number).gameObject.GetComponent<ButtonClick>().purchased = false;
            this.transform.GetChild(store_number).gameObject.GetComponent<ButtonClick>().armed = false;
        }

        else if (leftConcensus.value == 0 && rightConcensus.value == 1)
        {
            concensusBar.SetActive(false);

            Invoke("ShowFailed", 0f);

            failConcensus.Play();

            leftConcensus.value = 0.5f;
            rightConcensus.value = 0.5f;
            //store_is_purchased[ButtonClick.object_name] = false;
            //is_purchased = store_is_purchased[i];

            this.transform.GetChild(store_number).gameObject.GetComponent<ButtonClick>().purchased = false;
            this.transform.GetChild(store_number).gameObject.GetComponent<ButtonClick>().armed = false;
        }

        else if (leftConcensus.value == 0 && rightConcensus.value == 0)
        {
            concensusBar.SetActive(false);

            //Invoke("ShowFailed", 0f);

            //failConcensus.Play();

            leftConcensus.value = 0.5f;
            rightConcensus.value = 0.5f;
            //store_is_purchased[ButtonClick.object_name] = false;
            //is_purchased = store_is_purchased[i];

            this.transform.GetChild(store_number).gameObject.GetComponent<ButtonClick>().purchased = false;
            this.transform.GetChild(store_number).gameObject.GetComponent<ButtonClick>().armed = false;
        }

        //Debug.Log(is_purchased);

    }

    void Show()
    {
        purchaseSuccessful.SetActive(true);
        Invoke("Hide", 2f);
    }
    void Hide()
    {
        purchaseSuccessful.SetActive(false);
    }


    void ShowFailed()
    {
        purchaseFailed.SetActive(true);
        Invoke("HideFailed", 2f);
    }

    void HideFailed()
    {
        purchaseFailed.SetActive(false);
    }




}
