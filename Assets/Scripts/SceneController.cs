using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    public void Jump2Checkpoint()
    {
        // checkpoint scene will always be the last scene
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
        // SaveExPData("Jump2CheckPoint");
    }

    public void Back2Home()
    {
        resume();
        SceneManager.LoadScene(1);
        GlobalDataReset();
        // SaveExPData("Jump2Home");
    }

    public void Jump2CurrentLevel()
    {
        resume();
        SceneManager.LoadScene(GlobleData.currentLevel + 1);
        SaveExPData("Jump2LastLevel");
    }

    public void Jump2Level01()
    {
        resume();
        // GlobleData.setCurrentLevel(1);
        SceneManager.LoadScene(2);
        GlobleData.currentLevel = 1;
        //SaveExPData("Jump2Level01");
    }

    public void Jump2Level02()
    {
        resume();
        // GlobleData.setCurrentLevel(2);
        SceneManager.LoadScene(3);
        GlobleData.currentLevel = 2;
        //SaveExPData("Jump2Level02");
    }

    public void Jump2Level03()
    {
        resume();
        // GlobleData.setCurrentLevel(3);
        SceneManager.LoadScene(4);
        GlobleData.currentLevel = 3;
        //SaveExPData("Jump2Level03");
    }

    //public void Jump2Level00_Practice()
    //{
    //    resume();
    //    // GlobleData.setCurrentLevel(0);
    //    SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 3);
    //    GlobleData.currentLevel = 0;
    //    SaveExPData("Jump2Level00");
    //}

    public void Jump2Spacecraft()
    {
        GlobleData.last_scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 4);
        // SaveExPData("Jump2SpaceCraft");
    }

    private void resume()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
    }



    public void Levle01Jump2Result()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 2);
        GlobleData.setCurrentLevel(1);
        
        if (GlobleData.unlockedLevel < 2)
            GlobleData.unlockedLevel = 2;

        SaveExPData("LEVEL01JUMP2Result");
    }

    public void Levle02Jump2Result()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 2);
        GlobleData.setCurrentLevel(2);
        
        if (GlobleData.unlockedLevel < 3)
            GlobleData.unlockedLevel = 3;
        
        SaveExPData("LEVEL02JUMP2Result");
    }

    public void Levle03Jump2Result()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 2);
        GlobleData.setCurrentLevel(3);
        
        SaveExPData("LEVEL03JUMP2Result");
    }

    public void Level00Back2Home()
    {
        resume();
        SceneManager.LoadScene(1);
        SaveExPData("Level00Back2Home");
    }

    public void HomeBack2Opening()
    {
        SceneManager.LoadScene("Opening");
    }

    public void Jump2Practice()
    {
        SceneManager.LoadScene("Level00_Practice");
    }

    public void SaveExPData(string SceneJump)
    {

        GlobalDataUpdate();
        SaveEPData.SaveExsperimentalData(SceneJump);
        GlobalDataReset();
    }

    private void GlobalDataUpdate()
    {
        GlobleData.counthit_max = CountHit.counthit_max;
        GlobleData.counthit_total = CountHit.counthit_total;
        GlobleData.BallHitPaddleLeft = CountHit.Hit_Left;
        GlobleData.BallHitPaddleRight = CountHit.Hit_Right;
    }
    private void GlobalDataReset()
    {
        
        CountHit.counthit_max = 0;
        CountHit.counthit_total = 0;
        CountHit.Hit_Left = 0;
        CountHit.Hit_Right = 0;

        GlobleData.BallHitPaddleLeft = 0;
        GlobleData.BallHitPaddleRight = 0;

        GlobleData.counthit_total = 0;
        GlobleData.counthit_max = 0;
        GlobleData.MissingBall_total = 0;
        GlobleData.MissingBall_Left = 0;
        GlobleData.MissingBall_Right = 0;


        GlobleData.FrozenRightUsedTimes = 0;
        GlobleData.FireRightUsedTimes = 0;
        GlobleData.FrozenLeftUsedTimes = 0;
        GlobleData.FireLeftUsedTimes = 0;

    }





}
