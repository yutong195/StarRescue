using UnityEngine;
using UnityEngine.UI;


public class ShowVolume : MonoBehaviour
{
    public void SetBGVolume() {

        GameObject BGController = GameObject.Find("BG-Slider");
        if (BGController != null)
        {
            float volume = BGController.GetComponent<Slider>().value;
            this.GetComponent<Text>().text = (int)(volume * 10) + "";
            GlobleData.BackgroundMusic_Volume = volume;
        }
    }
    public void SetGEVolume()
    {
        GameObject GEController = GameObject.Find("ES-Slider");
        if (GEController != null)
        {
            float volume = GEController.GetComponent<Slider>().value;
            this.GetComponent<Text>().text = (int)((volume + 80) / 10) + "";
            GlobleData.GameEffectSound_Volume = volume;
        }
    }
}
