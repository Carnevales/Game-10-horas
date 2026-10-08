using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Project.Scripts.Managers
{
    public class LobbyManager : MonoBehaviour
    {
        public string gameSceneName = "Game";

        public void StartGame()
        {
            SceneManager.LoadScene(gameSceneName);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
