using UnityEngine;
using Assets.Project.Scripts.Enemy;

namespace Assets.Project.Scripts
{
    public class EnemyAttack : MonoBehaviour
    {
        public Animator animator;
        public EnemyConfig enemyConfig;

        public float intervaloAtaque = 1f;

        private float proximoAtaque;

        void Start()
        {
            if (animator == null)
                animator = GetComponentInChildren<Animator>();

            // Usa a mesma configuração do movimento.
            EnemyMovement movement = GetComponent<EnemyMovement>();

            if (enemyConfig == null && movement != null)
                enemyConfig = movement.enemyConfig;
        }

        void OnCollisionStay2D(Collision2D collision)
        {
            if (animator == null)
                return;

            if (animator.GetBool("morto"))
                return;

            PlayerStatus playerStatus =
                collision.collider.GetComponentInParent<PlayerStatus>();

            if (playerStatus == null)
                return;

            if (Time.time < proximoAtaque)
                return;

            proximoAtaque =
                Time.time + Mathf.Max(0.1f, intervaloAtaque);

            animator.SetTrigger("atacar");

            int damage = enemyConfig != null
                ? enemyConfig.contactDamage
                : 10;

            playerStatus.TakeDamage(damage);
        }
    }
}