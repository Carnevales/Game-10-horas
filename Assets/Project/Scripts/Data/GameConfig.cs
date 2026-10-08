using UnityEngine;

using UnityEngine;

namespace Assets.Project.Scripts.Data
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        public Vector2 arenaMin = new Vector2(-8, -4);
        public Vector2 arenaMax = new Vector2(8, 4);
        public Vector3 playerSpawn = Vector3.zero;
        public int[] waves = new int[] {5,8,12};
    }
}
