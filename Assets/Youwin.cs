using UnityEngine;
using UnityEngine.SceneManagement;
public class Youwin : MonoBehaviour
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
    public void Level2()
    {
        Debug.Log("Level2");
        SceneManager.LoadScene(3);
    }
}
