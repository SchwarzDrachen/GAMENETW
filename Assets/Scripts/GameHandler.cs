/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    //  Honestly could have made Game Manager script shorter but im too lazy (do the scripts in their respective Menus (Pause, GameOver, etc)
    public static GameManager instance;

    [SerializeField] private GameObject PauseCanvas;
    [SerializeField] private GameObject GameOverCanvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        ScoreScript._score = 0;

        Time.timeScale = 1.0f;
    }

    //  GAME OVER
    public void GameOver()
    {
        GameOverCanvas.SetActive(true);
        PauseMenu.isPaused = true;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseMenu.isPaused = false;
        Time.timeScale = 1.0f;
        ScoreScript._score = 0;
    }

    //  PAUSE
    public void Pause()
    {
        PauseCanvas.SetActive(true);
    }

    public void Resume()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu desu~");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
*/