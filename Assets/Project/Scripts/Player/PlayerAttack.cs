using UnityEngine;

using UnityEngine;
using Assets.Project.Scripts.Player;

public class PlayerAttack : MonoBehaviour
{
    public PlayerConfig playerConfig;
    public Animator animator;
    public float attackHold = 0.4f;

    PlayerMovement playerMovement;

    float lastFire;

    void Update()
    {
        if (playerConfig == null) return;
        if (Input.GetMouseButton(0) && Time.time - lastFire >= playerConfig.fireRate)
        {
            Fire();
            lastFire = Time.time;
        }
    }

    void Fire()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = new Vector2(mouse.x - transform.position.x, mouse.y - transform.position.y);
        dir.Normalize();
        if (playerMovement == null) playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null) playerMovement.SetDirectionOverride(dir, attackHold);
        if (animator != null)
        {
            animator.SetFloat("X", dir.x);
            animator.SetFloat("Y", dir.y);
            animator.SetTrigger("Attack");
        }
        GameObject prefab = playerConfig.projectilePrefab;
        if (prefab == null) return;
        GameObject p = Instantiate(prefab, transform.position + (Vector3)(dir * 0.5f), Quaternion.identity);
        p.transform.up = dir;
        Rigidbody2D rb = p.GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = dir * playerConfig.projectileSpeed;
    }
}
