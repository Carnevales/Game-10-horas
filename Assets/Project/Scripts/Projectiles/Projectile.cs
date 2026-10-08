using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 25;
    public float lifeTime = 4f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player")) return;
        if (c.CompareTag("Enemy")) return;
        Destroy(gameObject);
    }
}
