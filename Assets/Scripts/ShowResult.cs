using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowResult : MonoBehaviour
{

    void Start()
    {
        if (this.isActiveAndEnabled) {
            GetComponent<AudioSource>().Play();
            HitNumb.CountHit_max = CountHit.counthit_max;
            if (SceneManager.GetActiveScene()==SceneManager.GetSceneByName("Level00_Practice"))
            {
                GlobleData.Diamond += 0;
            }
            else
            {
                GlobleData.Diamond += CountHit.counthit_max;
            }
            
        }
    }


}
