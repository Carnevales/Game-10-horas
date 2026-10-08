using UnityEngine;
using Assets.Project.Scripts.Managers;
using Assets.Project.Scripts.Enemy;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public EnemyConfig enemyConfig;
    public int maxHealth = 30;
    public int currentHealth;

    void Start()
    {
        if (enemyConfig != null) maxHealth = enemyConfig.maxHealth;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        GameManager.Instance.EnemyDied();
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Projectile"))
        {
            Projectile p = c.GetComponent<Projectile>();
            if (p != null)
            {
                TakeDamage(p.damage);
            }
        }
    }
}
