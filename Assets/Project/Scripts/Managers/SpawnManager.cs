using System.Collections;
using UnityEngine;
using Assets.Project.Scripts.Data;

namespace Assets.Project.Scripts.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject playerPrefab;
        public GameObject enemyPrefab;
        public GameConfig gameConfig;

        void Start()
        {
            if (playerPrefab != null)
            {
                Instantiate(playerPrefab, gameConfig.playerSpawn, Quaternion.identity);
            }
        }

        public void SpawnWave(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Vector2 pos = GetRandomSpawnPosition();
                Instantiate(enemyPrefab, pos, Quaternion.identity);
            }
        }

        Vector2 GetRandomSpawnPosition()
        {
            Vector2 min = gameConfig.arenaMin;
            Vector2 max = gameConfig.arenaMax;
            Vector2 p = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            return p;
        }
    }
}
