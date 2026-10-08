using UnityEngine;

using UnityEngine;

namespace Assets.Project.Scripts.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public int maxHealth = 100;
        public float moveSpeed = 5f;
        public GameObject projectilePrefab;
        public float projectileSpeed = 10f;
        public float fireRate = 0.3f;
    }
}
