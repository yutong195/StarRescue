using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    static public string object_name;

    [SerializeField]
    public Button button;
    public GameObject component;
    public int Price=5;
    public bool purchased = false;
    public bool armed = false;
    public GameObject store;
    public GameObject concensusBar;
    
    //public Slider leftConcensus;
    //public Slider rightConcensus;

    // Start is called before the first frame update
    void Start()
    {
        
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        
    }

    void Update()
    {
        Refresh();
        //Debug.Log(purchased);
    }

    void TaskOnClick()
    {
        object_name = this.gameObject.name;
        if (!purchased)
        {
            //GlobleData.Diamond -= Price;
            //purchased = true;
            //armed = true;
            //Debug.Log(this.gameObject.name + purchased);
            concensusBar.SetActive(true);

            //if (Concensus.store_is_purchased[object_name])
            //{
            //    GlobleData.Diamond -= Price;
            //    purchased = true;
            //    armed = true;
            //    //component.SetActive(true);
            //}

            //else
            //{
            //    purchased = false;
            //    armed = false;
            //}
            //is_purchased = true;
        }

        else
        {
            if (component.activeInHierarchy)
            {
                //component.SetActive(false);
                armed = false;
            }

            else
            {
                //component.SetActive(true);
                armed = true;
            }
        }

        store.GetComponent<MySpacecraft>().SaveArmedData();
        store.GetComponent<MySpacecraft>().SavePurchaseddData();
        //store.GetComponent<MySpacecraft>().SaveIsPurchasedData();
        Refresh();
    }

    private void Refresh()
    {

        if(purchased)
        {
            button.GetComponent<Button>().interactable = true;

            if(armed)
            {
                component.SetActive(true);

            }
            else
            {
                component.SetActive(false);
            }
        }

        else
        {

            if(GlobleData.Diamond >= Price)
            {
                button.GetComponent<Button>().interactable = true;


            }
            else
            {
                button.GetComponent<Button>().interactable = false;
            }
        }
    }


}
