using Assets.Project.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Scripts.UI.Game
{
    public class VictoryUI : MonoBehaviour
    {
        public TMP_Text finalScoreText;

        void OnEnable()
        {
            if (finalScoreText != null) finalScoreText.text = GameManager.Instance != null ? GameManager.Instance.score.ToString() + "Pontos" : "0";
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
