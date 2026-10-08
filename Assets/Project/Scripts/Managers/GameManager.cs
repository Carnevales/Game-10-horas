using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Project.Scripts.Data;

namespace Assets.Project.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameConfig gameConfig;
        public int score;
        public int currentWave = 0;
        public int enemiesAlive = 0;

        public GameUI gameUI;
        public GameObject victoryUI;
        public GameObject defeatUI;

        void Awake()
        {
            if (Instance == null) Instance = this; else Destroy(gameObject);
        }

        void Start()
        {
            StartNextWave();
        }

        public void StartNextWave()
        {
            if (currentWave >= gameConfig.waves.Length)
            {
                Win();
                return;
            }
            currentWave++;
            enemiesAlive = gameConfig.waves[currentWave - 1];
            SpawnManager spawn = FindObjectOfType<SpawnManager>();
            if (spawn != null) spawn.SpawnWave(enemiesAlive);
            UpdateUI();
        }

        public void EnemyDied()
        {
            enemiesAlive--;
            score += 100;
            UpdateUI();
            if (enemiesAlive <= 0)
            {
                if (currentWave >= gameConfig.waves.Length) Win(); else Invoke(nameof(StartNextWave), 2f);
            }
        }

        public void PlayerDied()
        {
            defeatUI.SetActive(true);
            Time.timeScale = 0f;
        }

        void Win()
        {
            victoryUI.SetActive(true);
            Time.timeScale = 0f;
        }

        void UpdateUI()
        {
            if (gameUI != null)
            {
                gameUI.SetScore(score);
                gameUI.SetWave(currentWave, gameConfig.waves.Length);
            }
        }

        public void RestartScene()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void BackToMenu(string sceneName)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneName);
        }
    }
}
