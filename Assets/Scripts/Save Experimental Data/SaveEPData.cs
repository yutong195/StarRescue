public class SaveEPData
{
    public static void SaveExsperimentalData(string SceneJump)
    {
        string[] data_ = new string[7]{
                GlobleData.PlayerID,
                SceneJump,
                //GlobleData.BallHitPaddleLeft.ToString(),
                //GlobleData.BallHitPaddleRight.ToString(),
                GlobleData.counthit_max.ToString(),
                GlobleData.counthit_total.ToString(),

                GlobleData.MissingBall_total.ToString(),
                //GlobleData.MissingBall_Left.ToString(),
                //GlobleData.MissingBall_Right.ToString(),


                
                GlobleData.FrozenLeftUsedTimes.ToString(),
                //GlobleData.FireLeftUsedTimes.ToString(),
                //GlobleData.FrozenRightUsedTimes.ToString(),
                GlobleData.FireRightUsedTimes.ToString()
            };

        CSVManager.AppendToReport(data_);
    }
}
