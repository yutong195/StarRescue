
using UnityEngine;


public class SuperPowerUsed : MonoBehaviour
{

    public void FrozenRightPressed() {

        GlobleData.FrozenRightUsedTimes++;
    }
    public void FrozenLeftPressed()
    {

        GlobleData.FrozenLeftUsedTimes++;
    }
    public void FireRightPressed()
    {

        GlobleData.FireRightUsedTimes++;
    }
    public void FireLeftPressed()
    {

        GlobleData.FireLeftUsedTimes++;
    }


}
