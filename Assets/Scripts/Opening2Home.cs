using UnityEngine;
using UnityEngine.SceneManagement;

public class Opening2Home : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Go2Home", 3f);
    }

    public void Go2Home()
    {
        SceneManager.LoadScene(1);
    }

}
