using System.Collections;
using UnityEngine;
using Assets.Project.Scripts.Managers;
using Assets.Project.Scripts.Enemy;

public class EnemyStatus : MonoBehaviour
{
    public EnemyConfig enemyConfig;
    public int maxHealth = 30;
    public int currentHealth;

    public float tempoAnimacaoMorte = 2f;

    private Animator animator;
    private bool morreu;

    void Start()
    {
        if (enemyConfig != null)
            maxHealth = enemyConfig.maxHealth;

        currentHealth = maxHealth;
        animator = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if (morreu)
            return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            morreu = true;
            StartCoroutine(Morrer());
        }
    }

    IEnumerator Morrer()
    {
        EnemyMovement movement = GetComponent<EnemyMovement>();

        if (movement != null)
            movement.enabled = false;

        Assets.Project.Scripts.EnemyAttack attack =
            GetComponent<Assets.Project.Scripts.EnemyAttack>();

        if (attack != null)
            attack.enabled = false;

        foreach (Collider2D col in GetComponentsInChildren<Collider2D>())
            col.enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
            rb.simulated = false;

        if (animator != null)
        {
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;
            animator.SetBool("andando", false);
            animator.ResetTrigger("atacar");
            animator.SetBool("morto", true);
            animator.Play("Base Layer.Death", 0, 0f);
            animator.Update(0f);
        }

        // Espera mesmo se o jogo estiver com o tempo pausado.
        yield return new WaitForSecondsRealtime(
            Mathf.Max(tempoAnimacaoMorte, 0.1f)
        );

        if (GameManager.Instance != null)
            GameManager.Instance.EnemyDied();

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (morreu)
            return;

        if (c.CompareTag("Projectile"))
        {
            Projectile p = c.GetComponent<Projectile>();

            if (p != null)
                TakeDamage(p.damage);
        }
    }
}