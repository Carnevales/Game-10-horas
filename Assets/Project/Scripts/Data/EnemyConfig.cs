using UnityEngine;

using UnityEngine;

namespace Assets.Project.Scripts.Enemy
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        public int maxHealth = 30;
        public float moveSpeed = 2f;
        public int contactDamage = 10;
    }
}
