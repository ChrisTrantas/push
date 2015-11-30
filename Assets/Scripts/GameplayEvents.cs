using UnityEngine;
using System.Collections;

public class GameplayEvents : MonoBehaviour
{
    private bool gamePaused = false;
    private GameObject pauseButton;
    private GameObject pausePanel;
    private GameObject splashScreen;

    public void Start()
    {
        pauseButton = GameObject.FindGameObjectWithTag("pauseButton");
        pausePanel = GameObject.FindGameObjectWithTag("pausePanel");
        splashScreen = GameObject.FindGameObjectWithTag("splashScreen");

        // Activate Splash Screen
        splashScreen.SetActive(true);
        pauseButton.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale = 0.0f;
        gamePaused = true;
        StartCoroutine(EndSplashScreen());
    }


    public IEnumerator EndSplashScreen()
    {
        Debug.Log("wait");
        yield return new WaitForSeconds(1);
        Debug.Log("waited");
        pauseButton.SetActive(true);
        pausePanel.SetActive(true);
        splashScreen.SetActive(false);
    }

    public void TogglePauseState()
    {
        if (gamePaused)
        {
            Time.timeScale = 1.0f;
            gamePaused = false;
            pausePanel.SetActive(false);
            pauseButton.SetActive(true);
        }
        else
        {
            Time.timeScale = 0.0f;
            gamePaused = true;
            pausePanel.SetActive(true);
            pauseButton.SetActive(false);
        }
    }

    public void ResetLevel()
    {
        TogglePauseState();
        Application.LoadLevel(Application.loadedLevel);
    }
}
