using Assets.Project.Scripts.Managers;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

    public class DefeatUI : MonoBehaviour
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

