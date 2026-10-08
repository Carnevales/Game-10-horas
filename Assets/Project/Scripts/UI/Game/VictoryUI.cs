using UnityEngine;
using UnityEngine.UI;
using Assets.Project.Scripts.Managers;

namespace Assets.Project.Scripts.UI.Game
{
    public class VictoryUI : MonoBehaviour
    {
        public Text finalScoreText;

        void OnEnable()
        {
            if (finalScoreText != null) finalScoreText.text = GameManager.Instance != null ? GameManager.Instance.score.ToString() : "0";
        }

        public void PlayAgain()
        {
            GameManager.Instance.RestartScene();
        }

        public void BackToMenu(string sceneName)
        {
            GameManager.Instance.BackToMenu(sceneName);
        }
    }
}
