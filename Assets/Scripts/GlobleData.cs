using UnityEngine;

public class GlobleData : MonoBehaviour
{
    
    public static int maxLevel = 3;
    public static int currentLevel = 1;  // 当前关卡，当解锁了更高的关卡也可以选择更低的关卡重玩
    public static float paddleLength = 2f;
    public static float paddleThickness = 0.3f;
    //=======save to csv file=======

    public static string PlayerID="";

    public static int BallHitPaddleLeft=0;
    public static int BallHitPaddleRight=0;
    
    public static int counthit_max=0;
    public static int counthit_total = 0;

    public static int MissingBall_total = 0;
    public static int MissingBall_Left = 0;
    public static int MissingBall_Right = 0;

    public static int FrozenRightUsedTimes=0;
    public static int FireRightUsedTimes=0;
    public static int FrozenLeftUsedTimes=0;
    public static int FireLeftUsedTimes=0;

    //public static int lives = 3; 
    //============================================

    //========save to local file ========
    public static int unlockedLevel = 1; // 解锁的最高关卡

    //测试用，以后需要更改为0
    public static int Diamond = 0;
    public static int level01_star = 0;
    public static int level02_star = 0;
    public static int level03_star = 0;

    public static int[] Spacecraft_Purchased_Components = { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] Spacecraft_Armed_Components = { 0, 0, 0, 0, 0, 0, 0, 0 };
    //public static int[] Spacecraft_IsPurchased_Components = { 0, 0, 0, 0, 0, 0, 0, 0 };
    
    public static float BackgroundMusic_Volume = 5;
    public static float GameEffectSound_Volume = -30;
    //============================================

    public static string last_scene = "CheckpointScene";

    public static Vector2 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    public static Vector2 topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    public static float getLevelRadius(int level)
    {
        return 4.05f;
    }

    public static Vector3 getLevelCenter(int level)
    {
        if (level == 0)
            return new Vector3(0, -0.4f, 0);
        else
            return new Vector3(0, 0, 0);
    }

    public static float getLevelSpeed(int level)
    {
        return 1.2f;
    }

    public static void setCurrentLevel(int level)
    {
        currentLevel = level;
    }

    public void setBackgroundMusic_Volume(int volume)
    {
        BackgroundMusic_Volume = volume;
    }

    public void setGameEffectSound_Volume(int volume)
    {
        GameEffectSound_Volume = volume;
    }
}
