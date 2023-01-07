
using UnityEngine;
using UnityEngine.UI;

public class MySpacecraft : MonoBehaviour
{
   
    public GameObject Spacecraft;


    // Start is called before the first frame update
    void Start()
    {

        LoadData();
      
    }
    void Update()
    {

    }
    public void LoadData()
    {

        //load data
        for (int i = 1; i < Spacecraft.transform.childCount; i++)//i: 0-8：（1-8）【0-7】
        {

            //有没有买？

            //买了
            if (GlobleData.Spacecraft_Purchased_Components[i - 1] == 1)
            {
                this.transform.GetChild(i - 1).GetComponent<ButtonClick>().purchased = true;
                //用了
                if (GlobleData.Spacecraft_Armed_Components[i - 1] == 1)
                {
                    this.transform.GetChild(i - 1).GetComponent<ButtonClick>().armed = true;

                }
                //没用
                else
                {
                    this.transform.GetChild(i - 1).GetComponent<ButtonClick>().armed = false;
                }
            }
            //没买
            else
            {
                this.transform.GetChild(i - 1).GetComponent<ButtonClick>().purchased = false;

            }

        }
    }
    public void SaveArmedData()
    {
        int[] ArmedData = GlobleData.Spacecraft_Armed_Components;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).gameObject.GetComponent<ButtonClick>().armed)
            {
                ArmedData[i] = 1;
            }
            else {

                ArmedData[i] = 0;
            }
           
        }
        GlobleData.Spacecraft_Armed_Components = ArmedData;


        
    }
    public void SavePurchaseddData()
    {
        int[] PurchasedData = GlobleData.Spacecraft_Purchased_Components;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).gameObject.GetComponent<ButtonClick>().purchased)
            {
                PurchasedData[i] = 1;
            }
            else
            {

                PurchasedData[i] = 0;
            }
            
        }
        GlobleData.Spacecraft_Purchased_Components = PurchasedData;
        
    }

    //public void SaveIsPurchasedData()
    //{
    //    int[] IsPurchasedData = GlobleData.Spacecraft_IsPurchased_Components;

    //    for(int i = 0; i < this.transform.childCount; i++)
    //    {
    //        if (this.transform.GetChild(i).gameObject.GetComponent<ButtonClick>().)
    //    }
    //}

}
