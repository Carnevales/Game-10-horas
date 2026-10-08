using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public string gameSceneName = "Game";
    public string creditsUrl = "https://itch.io/colmeia-studios";

    public void Play()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenURL()
    {
        Application.OpenURL(creditsUrl);
    }
}
