using UnityEngine;

using Assets.Project.Scripts.Enemy;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyConfig enemyConfig;
    public Animator animator;
    Transform player;
    Rigidbody2D rb;


    private Vector2 movement;

    void Start()
    {
        player = FindObjectOfType<PlayerStatus>()?.transform;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        movement = movement.normalized;
        if (animator != null)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
            bool walking = movement.sqrMagnitude > 0.01f;
            animator.SetBool("Walk", walking);
            bool running = walking && Input.GetKey(KeyCode.LeftShift);
            animator.SetBool("Run", running);
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;
        Vector2 dir = (player.position - transform.position).normalized;
        float speed = enemyConfig != null ? enemyConfig.moveSpeed : 2f;
        if (rb != null) rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.CompareTag("Player"))
        {
            PlayerStatus ps = c.collider.GetComponent<PlayerStatus>();
            if (ps != null)
            {
                int dmg = enemyConfig != null ? enemyConfig.contactDamage : 10;
                ps.TakeDamage(dmg);
            }
        }
    }
}
