using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject AudioControllPanel;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {
        if (AudioControllPanel.activeInHierarchy)
        {
            AudioControllPanel.SetActive(false);
        }
        else {
            AudioControllPanel.SetActive(true);
        }
    }
}
