using Assets.Project.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

    public class VictoryUI : MonoBehaviour
    {
        public TMP_Text finalScoreText;

        public void SetScore(int mount)
        {
            if (finalScoreText != null) finalScoreText.text = mount + " Pontos";
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

