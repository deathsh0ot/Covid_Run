using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
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
    public void Restart()
    {
        Debug.Log("Level2");
        SceneManager.LoadScene(3);
    }
}
