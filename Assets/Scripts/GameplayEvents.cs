using UnityEngine;
using System.Collections;

public class GameplayEvents : MonoBehaviour
{
    private bool gamePaused = false;
    private GameObject pausePanel;

    public void Start()
    {
        pausePanel = GameObject.FindGameObjectWithTag("pausePanel");
        pausePanel.SetActive(false);
    }

    public void TogglePauseState()
    {
        if (gamePaused)
        {
            Time.timeScale = 1.0f;
            gamePaused = false;
            pausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0.0f;
            gamePaused = true;
            pausePanel.SetActive(true);
        }
    }

    public void ResetLevel()
    {
        TogglePauseState();
        Application.LoadLevel(Application.loadedLevel);
    }
}
