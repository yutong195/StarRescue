using UnityEngine;
using UnityEngine.UI;

public class GameSaving : MonoBehaviour
{
    public Text inputtext;
    //Call your save routine here
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
    }
    void OnApplicationQuit()
    {
        SavePlayer();
    }

    public void InputPlayerID() {
        string PlayerID = inputtext.GetComponent<Text>().text;
        GlobleData.PlayerID = PlayerID;

    }
    public void SavePlayer()
    {
        
        SaveSystem.SavePlayer();

    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            GlobleData.unlockedLevel = data.unlockedLevel;

            GlobleData.Diamond = data.Diamond;
            GlobleData.level01_star = data.level01_Star;
            GlobleData.level02_star = data.level02_Star;
            GlobleData.level03_star = data.level03_Star;

            GlobleData.Spacecraft_Purchased_Components = data.Spacecraft_Purchased_Components;
            GlobleData.Spacecraft_Armed_Components = data.Spacecraft_Armed_Components;

            GlobleData.BackgroundMusic_Volume = data.BGM_volume;
            GlobleData.GameEffectSound_Volume = data.GE_volume;

        }
        else {

            GlobleData.unlockedLevel = 1;

            GlobleData.Diamond = 0;
            GlobleData.level01_star = 0;
            GlobleData.level02_star = 0;
            GlobleData.level03_star = 0;

            GlobleData.Spacecraft_Purchased_Components = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            GlobleData.Spacecraft_Armed_Components = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

            GlobleData.BackgroundMusic_Volume = 5;
            GlobleData.GameEffectSound_Volume = 5;

        }
  
    }


}
