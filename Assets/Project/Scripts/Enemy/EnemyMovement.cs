using UnityEngine;
using Assets.Project.Scripts.Enemy;

public class EnemyMovement : MonoBehaviour
{
    public EnemyConfig enemyConfig;
    public Animator animator;

    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        PlayerStatus target = FindObjectOfType<PlayerStatus>();

        if (target != null)
            player = target.transform;

        rb = GetComponent<Rigidbody2D>();

        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    bool EstaMorto()
    {
        return animator != null && animator.GetBool("morto");
    }

    void Update()
    {
        movement = Vector2.zero;

        if (!EstaMorto() && player != null)
        {
            Vector2 direction = player.position - transform.position;

            if (direction.sqrMagnitude > 0.01f)
                movement = direction.normalized;
        }

        float speed = enemyConfig != null
            ? enemyConfig.moveSpeed
            : 2f;

        if (animator != null)
        {
            animator.SetBool(
                "andando",
                movement.sqrMagnitude > 0.01f && speed > 0f
            );
        }
    }

    void FixedUpdate()
    {
        if (EstaMorto() || player == null || rb == null)
            return;

        float speed = enemyConfig != null
            ? enemyConfig.moveSpeed
            : 2f;

        rb.MovePosition(
            rb.position + movement * speed * Time.fixedDeltaTime
        );
    }
}