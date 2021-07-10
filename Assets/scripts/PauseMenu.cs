using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public static bool GameOver = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameOver)
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void RestartGame()
    {
        GameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void GameOverScreen()
    {
        gameOverUI.SetActive(true);
        StartCoroutine(waitBeforeEnd());
        GameOver = true;
    }

    IEnumerator waitBeforeEnd()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0f;
    }
}
