using UnityEngine;

using UnityEngine;
using Assets.Project.Scripts.Player;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public PlayerConfig playerConfig;
    public Animator animator;

    private Rigidbody2D rb;
    private Vector2 movement;
    bool blockAnimatorUpdates = false;
    Coroutine dirOverrideCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        if (animator != null && !blockAnimatorUpdates)
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
        if (rb == null) return;
        float speed = playerConfig != null ? playerConfig.moveSpeed : 5f;
        bool running = Input.GetKey(KeyCode.LeftShift);
        float mod = running ? 1.5f : 1f;
        rb.MovePosition(rb.position + movement * speed * mod * Time.fixedDeltaTime);
    }

    public void SetDirectionOverride(Vector2 dir, float duration)
    {
        if (dirOverrideCoroutine != null) StopCoroutine(dirOverrideCoroutine);
        dirOverrideCoroutine = StartCoroutine(DirectionOverrideCoroutine(dir, duration));
    }

   IEnumerator DirectionOverrideCoroutine(Vector2 dir, float duration)
    {
        blockAnimatorUpdates = true;
        if (animator != null)
        {
            animator.SetFloat("X", dir.x);
            animator.SetFloat("Y", dir.y);
        }
        yield return new WaitForSeconds(duration);
        blockAnimatorUpdates = false;
        dirOverrideCoroutine = null;
    }
}
