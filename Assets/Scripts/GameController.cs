using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public AudioSource buttonAudio;

    [SerializeField]
    public GameObject pausePanel;
    

    // Pause Game. Make the game stopped.
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        buttonAudio.Play();
        Invoke("ClosePanel", 0.1f);
    }

    private void ClosePanel()
    {
        pausePanel.SetActive(false);
    }

}
