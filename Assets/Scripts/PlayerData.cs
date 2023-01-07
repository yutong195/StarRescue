[System.Serializable]
public class PlayerData
{
    public int unlockedLevel;

    public int level01_Star;
    public int level02_Star;
    public int level03_Star;

    public int Diamond;
    public int[] Spacecraft_Armed_Components;
    public int[] Spacecraft_Purchased_Components;

    public float BGM_volume;
    public float GE_volume;

    public PlayerData() {
        unlockedLevel = GlobleData.unlockedLevel;

        //save audio settings
        BGM_volume = GlobleData.BackgroundMusic_Volume;
        GE_volume = GlobleData.GameEffectSound_Volume;

        level01_Star = GlobleData.level01_star;
        level02_Star = GlobleData.level02_star;
        level03_Star = GlobleData.level03_star;

        Diamond = GlobleData.Diamond;

        Spacecraft_Purchased_Components = GlobleData.Spacecraft_Purchased_Components;
        Spacecraft_Armed_Components = GlobleData.Spacecraft_Armed_Components;
    }
}
